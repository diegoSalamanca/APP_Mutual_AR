
using UnityEngine;
using UnityEngine.UI;

public class SliderExtintoresActivity : MonoBehaviour
{

    private void OnEnable()
    {        

        var slider = GetComponent<Slider>();
        slider.value = 0;

    }
    
}
