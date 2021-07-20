
using UnityEngine;


public class SPDC_activity_2 : MonoBehaviour
{
    public GameObject[] arnes;
    public TextListScriptable[] textListScriptables;    
    ARSoundsController aRSoundsController;


    private void OnEnable()
    {        
        
        aRSoundsController = FindObjectOfType<ARSoundsController>();
        aRSoundsController.StopSincronizeAudio();

        DisableArnes();

        ActiveArnes(0);


    }

    void DisableArnes()
    {
        foreach (var item in arnes)
        {
            item.SetActive(false);
        }
    }

    public void ActiveArnes(int index)
    {

        DisableArnes();
        arnes[index].SetActive(true);
        aRSoundsController.PlayAuidoClip(textListScriptables[index]);

    }

   
}


