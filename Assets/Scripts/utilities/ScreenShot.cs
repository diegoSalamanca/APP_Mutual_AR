using UnityEngine;
using System.Collections;

public class ScreenShot : MonoBehaviour
{
    public string screenshot_name;

#if UNITY_EDITOR

    int index = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot(screenshot_name+".png");
            print("Captura"+ screenshot_name + " realizada");

            
        }

        if (Input.GetKeyDown(KeyCode.V))
        {

            StartCoroutine(Saveframes());

        }
    }

    public IEnumerator Saveframes()
    {
        while (Input.GetKey(KeyCode.V))
        {
            ScreenCapture.CaptureScreenshot(screenshot_name + index + ".png");
            index += 1;
            yield return new WaitForSeconds(0.5F);
        }
        
    }

#endif

}
