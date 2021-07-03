
using UnityEngine;

public class DisableOnMobile : MonoBehaviour
{

#if UNITY_EDITOR

   
    private void Awake()
    {
        gameObject.SetActive(true);
    }

#else
 // Start is called before the first frame update

    private void Awake()
    {
        gameObject.SetActive(false);
    }


#endif





}
