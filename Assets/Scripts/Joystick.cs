using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick: MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image jsBackground;
    Image joystick;

    Vector3 inputDir;

    void Start()
    {
        jsBackground = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(jsBackground.rectTransform, eventData.position, eventData.pressEventCamera, out pos);

        pos.x = (pos.x / jsBackground.rectTransform.sizeDelta.x);
        pos.y = (pos.y / jsBackground.rectTransform.sizeDelta.y);

        float x = jsBackground.rectTransform.pivot.x == 1f ? pos.x * 2 + 1 : pos.x * 2 - 1;
        float y = jsBackground.rectTransform.pivot.y == 1f ? pos.y * 2 + 1 : pos.y * 2 - 1;

        inputDir = new Vector3(x, y, 0);

        inputDir = inputDir.magnitude > 1 ? inputDir.normalized : inputDir;

        joystick.rectTransform.anchoredPosition = new Vector3(inputDir.x * (jsBackground.rectTransform.sizeDelta.x / 3)
            , inputDir.y * (jsBackground.rectTransform.sizeDelta.y) / 3);
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
