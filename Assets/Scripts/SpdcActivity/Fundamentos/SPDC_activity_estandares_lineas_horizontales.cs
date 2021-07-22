
using UnityEngine;


public class SPDC_activity_estandares_lineas_horizontales : MonoBehaviour
{
    public TextListScriptable[] textListScriptables;
    public GameObject buttonNext;
    public GameObject[] optionObjects;
    
    ARSoundsController aRSoundsController;
    int audioIndex;

    private void OnEnable()
    {
        audioIndex = 0;
        aRSoundsController = FindObjectOfType<ARSoundsController>();        
        buttonNext.SetActive(false);
        DisableObjects();
        Next();

    }

    public void Next()
    {
        buttonNext.SetActive(false);
        DisableObjects();
        aRSoundsController.PlayAuidoClipAndAction(textListScriptables[audioIndex], AudioFinish);
        optionObjects[audioIndex].SetActive(true);
        audioIndex += 1;

    }

    public void AudioFinish()
    {
        if (audioIndex < textListScriptables.Length)
        {
            buttonNext.SetActive(true);
        }
        
    }

    

    void DisableObjects()
    {
        foreach (var item in optionObjects)
        {
            item.SetActive(false);
        }
    }

}


