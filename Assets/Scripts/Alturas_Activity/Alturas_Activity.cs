using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alturas_Activity : MonoBehaviour
{
    public ARSoundsController soundsController;

    public TextListScriptable goodAnswerScriptable, badAnswerScriptable;

    public Animator playerAnimator, chairAnimator;

    //public AudioSource AudioSource;

    //public AudioClip correctAnswer, badAnswer;

    public Transform playerContainer;

    public Vector3 posEscalera, posCaida, deafultPos;


    public void SelectEscalera()
    {
        //AudioSource.PlayOneShot(correctAnswer);
        soundsController.PlayAuidoClip(goodAnswerScriptable);
        playerContainer.localPosition = posEscalera;
        playerAnimator.SetTrigger("subir");

    }

    public void SelectSilla()
    {
        //AudioSource.PlayOneShot(badAnswer);
        soundsController.PlayAuidoClip(badAnswerScriptable);
        chairAnimator.SetTrigger("anim");
        playerAnimator.SetTrigger("caida");
        playerContainer.localPosition = posCaida;
    }

    private void OnEnable()
    {
        playerAnimator.SetTrigger("idle");
        playerContainer.localPosition = deafultPos;
    }
}
