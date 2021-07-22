
using UnityEngine;


public class SPDC_activity_3 : MonoBehaviour
{
    public TextListScriptable[] textListScriptables;
    public GameObject buttonsContainer;
    public GameObject[] optionObjects;
    
    ARSoundsController aRSoundsController;


    private void OnEnable()
    {        
        
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        //aRSoundsController.StopSincronizeAudio();
        buttonsContainer.SetActive(true);
        DisableObjects();

    }

    public void CorrectAnswer()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[2]);
        buttonsContainer.SetActive(false);
        optionObjects[0].SetActive(true);
    }


    public void IncorrectAnswer(int index)
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[1]);
        buttonsContainer.SetActive(false);
        optionObjects[index].SetActive(true);

    }

    void DisableObjects()
    {
        foreach (var item in optionObjects)
        {
            item.SetActive(false);
        }
    }

}


