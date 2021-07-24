
using UnityEngine;

public class ArMicroCapsulePlayAllSounds : MonoBehaviour
{

    ARSoundsController aRSoundsController;
    int audioIndex;

    public TextListScriptable[] textListScriptables;


    private void OnEnable()
    {
        audioIndex = 0;
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        
        Next();

    }

    public void Next()
    {
       
        aRSoundsController.PlayAuidoClipAndAction(textListScriptables[audioIndex], AudioFinish);       
        

    }

    public void AudioFinish()
    {
        audioIndex += 1;

        if (audioIndex < textListScriptables.Length)
        {
            Next();
        }

    }
}
