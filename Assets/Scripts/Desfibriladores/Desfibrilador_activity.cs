
using UnityEngine;


public class Desfibrilador_activity : MonoBehaviour
{
    public TextListScriptable[] textListScriptables;
    
    public GameObject[] optionObjects;

    public GameObject[] UiControls;

    ARSoundsController aRSoundsController;

    int index;


    private void OnEnable()
    {
        index = 0;
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        disableControls();
        DisableObjects();
        Next();
        Invoke("Next", 2f);


    }

    public void Next()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[index]);
        DisableObjects();
        optionObjects[index].SetActive(true);
        UiControls[index].SetActive(true);
        index += 1;
        
    }



    void DisableObjects()
    {
        foreach (var item in optionObjects)
        {
            item.SetActive(false);
        }
    }

    public void SliderEvaluateControl(float value)
    {

        if (value > 0.9f)
        {
            disableControls();
            Invoke("Next", 2f);
            

        }
    }

    void disableControls()
    {
        foreach (var item in UiControls)
        {
            item.SetActive(false);
        }
    }

}


