using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExtintoresActivity : MonoBehaviour
{

    ARSoundsController soundsController;

    int indexActivity = 0;

    public GameObject[] UiControls;

    public Image buttonManillaImage;

    public Sprite[] spritesManilla;

    

    Coroutine ManillaCorutine;

    private void OnEnable()
    {
        soundsController = FindObjectOfType<ARSoundsController>();
        indexActivity = 0;
        disableControls();
        UiControls[0].SetActive(true);

        buttonManillaImage.sprite = spritesManilla[0];

        

    }

    void disableControls()
    {
        foreach (var item in UiControls)
        {
            item.SetActive(false);
        }
    }

    public void NextStep()
    {
        indexActivity += 1;
        soundsController.ExtintoresNextStep(indexActivity);        
        disableControls();
        if (indexActivity < UiControls.Length)
        {
            UiControls[indexActivity].SetActive(true);
        }

        

    }

    public void SliderEvaluateControl1(float value)
    {

        if (value > 0.9f)
        {
            NextStep();
        }
    }

    public void SliderEvaluateControl2(float value)
    {
        if (value > 0.9f)
        {
            NextStep();
        }
    }

    public void ButtonManillaPress()
    {
        ManillaCorutine = StartCoroutine(ManillaPress());
        buttonManillaImage.sprite = spritesManilla[1];
    }


    public void ButtonManillaUnPress()
    {
        StopCoroutine(ManillaCorutine);
        buttonManillaImage.sprite = spritesManilla[0];
    }

    IEnumerator ManillaPress()
    {

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
        }

        NextStep();

    }
}
