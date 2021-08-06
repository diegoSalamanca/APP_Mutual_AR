
using UnityEngine;


public class Desfibrilador_activity : MonoBehaviour
{
    public TextListScriptable[] textListScriptables;
    
    

    public GameObject[] UiControls;

    ARSoundsController aRSoundsController;

    public Animator animatorPj, animatorDesfibrilador;

    public AudioSource audioSource;

    public AudioClip[] clips;

    bool electrode1, electrode2 = false;

    int shocks = 0;


    private void OnEnable()
    {
        
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        
        electrode1 = false;
        electrode2 = false;
        
        StartActivity();

    }

    public void StartActivity()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[0]);
        disableControls();
        animatorDesfibrilador.SetTrigger("idle");
        Invoke("EnableOn", 2f);
    }

    public void EnableOn()
    {
        aRSoundsController.PlayAuidoClip(textListScriptables[1]);
        
        disableControls();
        
        UiControls[0].SetActive(true);
        shocks = 0;
    }

    public void ButtonOn()
    {
        disableControls();              
        Invoke("EnableElectrodos", 2f);
        animatorDesfibrilador.SetTrigger("on");
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
                animatorDesfibrilador.SetTrigger("electrode");

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
                animatorDesfibrilador.SetTrigger("electrode");

            }

        }
    }

    public void EnableConector()
    {
        
        disableControls();
        aRSoundsController.PlayAuidoClip(textListScriptables[3]);
        
        UiControls[2].SetActive(true);

    }



    public void SliderEvaluateControlConector(float value)
    {

        if (value > 0.9f)
        {
            disableControls();
            Invoke("EnableDescarga", 2f);
            animatorDesfibrilador.SetTrigger("conect");

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
        animatorDesfibrilador.SetTrigger("shock");
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


