
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResetSlider : MonoBehaviour, IPointerUpHandler
{

    private void OnEnable()
    {
        var slider = GetComponent<Slider>();
        slider.value = 0;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        var slider = GetComponent<Slider>();

        if (slider.value < 0.9f)
            slider.value = 0;
    }

   
}
