using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image joystickBg;
    private Image joystick;
    private Vector2 posInput;

    private void Start()
    {
        joystickBg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out posInput))
        {
            posInput.x = posInput.x / (joystickBg.rectTransform.sizeDelta.x);
            posInput.y = posInput.y / (joystickBg.rectTransform.sizeDelta.y);

            // Debug.Log(posInput.x.ToString() + "/" + posInput.y.ToString());

            if (posInput.magnitude > 1.0f)
            {
                posInput = posInput.normalized;
            }

            joystick.rectTransform.anchoredPosition = new Vector2(posInput.x * (joystickBg.rectTransform.sizeDelta.x / 4), posInput.y * (joystickBg.rectTransform.sizeDelta.y / 4));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        posInput = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float InputHorizontal()
    {
        if (posInput.x != 0)
        {
            return posInput.x;

        }

        else
        {
            return Input.GetAxis("Horizontal");

        }

    }
    public float InputVertical()
    {
        if (posInput.y != 0)
        {
            return posInput.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
