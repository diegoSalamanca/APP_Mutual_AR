
using UnityEngine;


public class SPDC_activity_1 : MonoBehaviour
{
    public GameObject[] UiControls;
    public TextListScriptable[] textListScriptables;
    int indexActivity = 0;
    ARSoundsController aRSoundsController;
    public Animator pjAnimator, cuerdaAnimator;

    public GameObject arnes;


    private void OnEnable()
    {        
        indexActivity = 0;
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        aRSoundsController.StopSincronizeAudio();

        pjAnimator.SetTrigger("idle");
        cuerdaAnimator.SetTrigger("idle");
        arnes.SetActive(false);

        disableControls();
        NextStep();
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

        if (indexActivity < UiControls.Length)
        {
            UiControls[indexActivity].SetActive(true);
            aRSoundsController.PlayAuidoClip(textListScriptables[indexActivity]);
        }

        indexActivity += 1;


    }

    public void SliderEvaluateControl1(float value)
    {

        if (value > 0.9f)
        {
            arnes.SetActive(true);
            disableControls();
            Invoke("NextStep", 2f);

        }
    }

    public void SliderEvaluateControl2(float value)
    {
        if (value > 0.9f)
        {
            pjAnimator.SetTrigger("subir");
            cuerdaAnimator.SetTrigger("subir");
            
            disableControls();
            Invoke("NextStep", 2f);

        }
    }

    public void SliderEvaluateControl3(float value)
    {
        if (value > 0.9f)
        {
            pjAnimator.SetTrigger("enganchar");
            cuerdaAnimator.SetTrigger("enganchar");
            disableControls();
            Invoke("NextStep", 2f);

        }
    }

    public void SliderEvaluateControl4(float value)
    {
        if (value > 0.9f)
        {
            pjAnimator.SetTrigger("bajar");
            cuerdaAnimator.SetTrigger("bajar");
            disableControls();
            Invoke("NextStep", 2f);

        }
    }

}


