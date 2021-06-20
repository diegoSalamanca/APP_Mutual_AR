using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCloseApp : MonoBehaviour
{

    public GameObject CloseConfirm;

    // Start is called before the first frame update

    public void EnableConfirm()
    {
        CloseConfirm.transform.SetAsLastSibling();
        CloseConfirm.SetActive(true);
        iTween.ScaleFrom(CloseConfirm, Vector3.zero, 0.5f);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
