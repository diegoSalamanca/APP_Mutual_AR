
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonsSlideController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float scrollSpeed;
    bool move = false; 

    private void Update()
    {
        if (move)
        {
            MoveScroll(scrollSpeed);
            print("moving");
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        move = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
    }

    private void OnEnable()
    {
        var scroll = FindObjectOfType<HorizontalScroll>().GetComponent<Scrollbar>();
        scroll.value = 0;
        move = false;
    }

    void MoveScroll(float value)
    {
        var scroll = FindObjectOfType<HorizontalScroll>().GetComponent<Scrollbar>();
        if (value > 0)
        {
            scroll.value += value * Time.deltaTime;
        }

        if (value < 0)
        {
            scroll.value += value * Time.deltaTime;
        }
    }

    
}
