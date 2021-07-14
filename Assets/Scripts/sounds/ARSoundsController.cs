using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARSoundsController : MonoBehaviour
{
    public bool secondaryActivity, extintoresActivity;
    
    AudioSource audioSource;
    public Slider slider;
    //public AudioClip[] audioClips;
    public TMPro.TextMeshProUGUI textMesh;
    public TextListScriptable[] textListScriptables;
    Coroutine coroutine;
    public string ButtonsMessage;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ExtintoresNextStep(int newIndex)
    {
        if (extintoresActivity)
        {
           
            coroutine = StartCoroutine(SincronizeAudio(newIndex));
        }
    }


    public void PlayAuido(int index)
    {
        StopAllCoroutines();
        if (extintoresActivity)
        {
            coroutine = StartCoroutine(SincronizeAudio(0));
        }
        else
        {
            coroutine = StartCoroutine(SincronizeAudio(index));
        }
        
    }

    public void PlayAuidoClip(TextListScriptable textListScriptable)
    {
        StopAllCoroutines();
        coroutine = StartCoroutine(SincronizeAudio(textListScriptable));
    }


    IEnumerator SincronizeAudio(int index)
    {

        if (textListScriptables[index].audioClip)
        {
            var clip = textListScriptables[index].audioClip;
            audioSource.clip = clip;
            audioSource.Play();

            while (audioSource.time < clip.length)
            {
                var actualSegment = (int)(textListScriptables[index].texts.Length * audioSource.time / clip.length);
                

                var value = ((1 * audioSource.time) / clip.length);
                slider.value = value;
                if (actualSegment < textListScriptables[index].texts.Length)
                {
                    textMesh.text = textListScriptables[index].texts[actualSegment];
                }

                yield return null;
            }

            yield return null;

            textMesh.text = "";
        }

        else
        {            
            slider.value = 0;
            audioSource.Stop();
            var segment =  (1 / (float)textListScriptables[index].texts.Length);
            

            for (int i = 0; i < textListScriptables[index].texts.Length; i++)
            {                
                textMesh.text = textListScriptables[index].texts[i];
                slider.value += segment;
                yield return new WaitForSeconds(3f);
                
            }

            yield return new WaitForSeconds(3f);
            textMesh.text = "";
        }
        


        if (index == 0 && !secondaryActivity && !extintoresActivity)
        {
            var message = Instantiate(Resources.Load("Prefabs/MessagePanel"), FindObjectOfType<MainCanvas>().transform) as GameObject;
            message.GetComponent<MessagePanel>().SetMessage(ButtonsMessage);
        }
        else if (secondaryActivity)
        {
            var activity = Instantiate(Resources.Load("Prefabs/Actividad_trabajo_alturas_Accientes"), FindObjectOfType<MainCanvas>().transform) as GameObject;
            
        }  

    }

    IEnumerator SincronizeAudio(TextListScriptable textListScriptable)
    {

        var clip = textListScriptable.audioClip;

        audioSource.clip = clip;
        audioSource.Play();

        while (audioSource.time < clip.length)
        {

            var actualSegment = (int)(textListScriptable.texts.Length * audioSource.time / clip.length);
            print(actualSegment);

            var value = ((1 * audioSource.time) / clip.length);
            slider.value = value;
            if (actualSegment < textListScriptable.texts.Length)
            {
                textMesh.text = textListScriptable.texts[actualSegment];
            }

            yield return null;
        }

        yield return null;

        textMesh.text = "";

    }


}
