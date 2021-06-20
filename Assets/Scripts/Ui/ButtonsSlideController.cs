using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSlideController : MonoBehaviour
{
    public Button leftButton, RightButton;

    public Scrollbar scroll;

    public ScrollRect scrollRect;

    public float scrollMoveDistance;

    // Start is called before the first frame update
    void Start()
    {
        leftButton.onClick.AddListener(ToLeft);
        RightButton.onClick.AddListener(ToRight);        
    }


    void ToLeft()
    {
        scrollRect.verticalNormalizedPosition = 0f;
        if (scroll.value > 0)
            scroll.value = 0;
    }

    void ToRight()
    {
        scrollRect.verticalNormalizedPosition = 1f;
        if (scroll.value < 1)
            scroll.value = 1;
        
    }
}
