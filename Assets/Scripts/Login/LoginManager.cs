using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{

    public TMPro.TMP_InputField _InputField;
    public GameObject loginButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_InputField.text.Length > 5)
        {
            loginButton.SetActive(true);
        }
        else
        {
            loginButton.SetActive(false);
        }
       
    }
}
