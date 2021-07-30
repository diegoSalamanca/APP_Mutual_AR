
using UnityEngine;


public class Desfibrilador_activity : MonoBehaviour
{
    public TextListScriptable[] textListScriptables;
    
    public GameObject[] optionObjects;

    public GameObject[] UiControls;

    ARSoundsController aRSoundsController;

    public Animator animatorPj;

    public AudioSource audioSource;

    public AudioClip[] clips;

    bool electrode1, electrode2 = false;

    int shocks = 0;


    private void OnEnable()
    {
        
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        electrode1 = false;
        electrode2 = false;
        DisableObjects();
        StartActivity();

    }

    public void StartActivity()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[0]);
        disableControls();
        DisableObjects();
        Invoke("EnableOn", 2f);
    }

    public void EnableOn()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[1]);
        DisableObjects();
        disableControls();
        
        UiControls[0].SetActive(true);
        shocks = 0;
    }

    public void ButtonOn()
    {
        disableControls();              
        Invoke("EnableElectrodos", 2f);
        optionObjects[0].SetActive(true);
        audioSource.PlayOneShot(clips[0]);
    }

    public void EnableElectrodos()
    {
        
        disableControls();
        aRSoundsController.PlayAuidoClip(textListScriptables[2]);
        
        UiControls[1].SetActive(true);
    }

    public void SliderEvaluateControlElectrode1(float value)
    {

        if (value > 0.9f)
        {
            electrode1 = true;
            if (electrode1 && electrode2)
            {
                disableControls();
                Invoke("EnableConector", 2f);
                optionObjects[1].SetActive(true);
            }
            

        }
    }

    public void SliderEvaluateControlElectrode2(float value)
    {

        if (value > 0.9f)
        {
            electrode2 = true;
            if (electrode1 && electrode2)
            {
                disableControls();
                Invoke("EnableConector", 2f);
                optionObjects[1].SetActive(true);
            }

        }
    }

    public void EnableConector()
    {
        
        disableControls();
        aRSoundsController.PlayAuidoClip(textListScriptables[3]);
        
        UiControls[2].SetActive(true);

    }



    void DisableObjects()
    {
        foreach (var item in optionObjects)
        {
            item.SetActive(false);
        }
    }

    public void SliderEvaluateControlConector(float value)
    {

        if (value > 0.9f)
        {
            disableControls();
            Invoke("EnableDescarga", 2f);
            optionObjects[2].SetActive(true);

        }
    }

    public void EnableDescarga()
    {
        
        disableControls();
        aRSoundsController.PlayAuidoClip(textListScriptables[4]);
       
        UiControls[3].SetActive(true);
    }

    public void NewShock()
    {
        UiControls[3].SetActive(true);
        

    }

    public void ShockButton()
    {
        if (shocks >= 2)
        {
            FinalAudio();
            return;
        }
        animatorPj.SetTrigger("shock");
        shocks += 1;
        disableControls();
        audioSource.PlayOneShot(clips[4]);
        Invoke("NewShock", 2f);

    }

    public void FinalAudio()
    {
        disableControls();
        
        aRSoundsController.PlayAuidoClip(textListScriptables[5]);
        
    }


    void disableControls()
    {
        foreach (var item in UiControls)
        {
            item.SetActive(false);
        }
    }

}


