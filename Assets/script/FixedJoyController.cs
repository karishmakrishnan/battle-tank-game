
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoyController : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    [HideInInspector]
    protected bool pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed=true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed=false;
    }
}
