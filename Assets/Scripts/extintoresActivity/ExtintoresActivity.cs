using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExtintoresActivity : MonoBehaviour
{

    ARSoundsController soundsController;

    int indexActivity = 0;

    public int ExtintorType;

    public int objectType;

    public GameObject[] UiControls;

    public Image buttonManillaImage;

    public Sprite[] spritesManilla;

    public ParticleSystem quimicoExtintor, fuego;

    public AudioSource audioFuego, audioExtintor;

    public Animator animatorManguera, animatorArgolla, animatorSello;

    public Texture[] extintoresTextures;
    public GameObject[] objects;

    public GameObject sello, argolla;


    public Material extintorMaterial;
    

    Coroutine ManillaCorutine;

    private void OnEnable()
    {
        foreach (var item in objects)
        {
            item.SetActive(false);
        }

        objects[objectType].SetActive(true);

        extintorMaterial.mainTexture = extintoresTextures[ExtintorType];

        soundsController = FindObjectOfType<ARSoundsController>();
        indexActivity = 0;
        disableControls();
        UiControls[0].SetActive(true);

        buttonManillaImage.sprite = spritesManilla[0];

        var part = fuego.main;
        part.maxParticles = 10;

        audioFuego.Play();

        animatorManguera.SetTrigger("idle");
        animatorArgolla.SetTrigger("idle");
        animatorSello.SetTrigger("idle");

        //sello.SetActive(true);
        argolla.SetActive(true);
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
            animatorArgolla.SetTrigger("anim");
            animatorSello.SetTrigger("anim");
        }
    }

    public void SliderEvaluateControl2(float value)
    {
        if (value > 0.9f)
        {
            NextStep();
            animatorManguera.SetTrigger("anim");
            DisableSelloYArgolla();
        }
    }

    public void ButtonManillaPress()
    {
        ManillaCorutine = StartCoroutine(ManillaPress());
        buttonManillaImage.sprite = spritesManilla[1];
        audioExtintor.Play();
        quimicoExtintor.Play();
    }


    public void ButtonManillaUnPress()
    {
        StopCoroutine(ManillaCorutine);
        buttonManillaImage.sprite = spritesManilla[0];
        audioExtintor.Stop();
        quimicoExtintor.Stop();
    }

    IEnumerator ManillaPress()
    {
        var part = fuego.main;
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);            
            part.maxParticles -= 2;
            if (part.maxParticles == 0)
            {
                fireEnds();
                yield break;
            }
                
        }
        part.maxParticles = 0;
    }

    void fireEnds()
    {
        audioExtintor.Stop();
        quimicoExtintor.Stop();
        audioFuego.Stop();
        NextStep();
    }

    public void DisableSelloYArgolla()
    {
        sello.SetActive(false);
        argolla.SetActive(false);
    }
}
