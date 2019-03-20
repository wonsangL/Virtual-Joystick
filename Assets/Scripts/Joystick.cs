using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick: MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Image jsBackground;
    Image joystick;

    private Vector2 inputDir;

    void Start()
    {
        jsBackground = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(jsBackground.rectTransform, eventData.position, eventData.pressEventCamera, out pos);

        float x = (pos.x / jsBackground.rectTransform.rect.width) * 2;
        float y = (pos.y / jsBackground.rectTransform.rect.height) * 2;

        inputDir = new Vector2(x, y);
        inputDir = inputDir.magnitude > 1 ? inputDir.normalized : inputDir;

        float joystickPosX = Mathf.Abs(pos.x) > jsBackground.rectTransform.rect.width / 2 ? pos.normalized.x * jsBackground.rectTransform.rect.width / 2 : pos.x;
        float joystickPosY = Mathf.Abs(pos.y) > jsBackground.rectTransform.rect.height / 2 ? pos.normalized.y * jsBackground.rectTransform.rect.height / 2 : pos.y;
                
        joystick.rectTransform.anchoredPosition = new Vector3(joystickPosX, joystickPosY);
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

    public Vector2 GetInputVector()
    {
        return inputDir;
    }
}
