using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick: MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image jsBackground;
    Image joystick;

    public Vector3 inputDir;

    void Start()
    {
        jsBackground = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        //screen space position을 rectransform의 local position으로 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(jsBackground.rectTransform, eventData.position, eventData.pressEventCamera, out pos);

        pos.x = (pos.x / jsBackground.rectTransform.rect.width);
        pos.y = (pos.y / jsBackground.rectTransform.rect.height);

        float x = pos.x * 2;
        float y = pos.y * 2;

        inputDir = new Vector3(x, y, 0);

        Debug.Log(inputDir);

        inputDir = inputDir.magnitude > 1 ? inputDir.normalized : inputDir;

        joystick.rectTransform.anchoredPosition = new Vector3(inputDir.x * (jsBackground.rectTransform.sizeDelta.x / 2)
            , inputDir.y * (jsBackground.rectTransform.sizeDelta.y) / 2);
       
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
