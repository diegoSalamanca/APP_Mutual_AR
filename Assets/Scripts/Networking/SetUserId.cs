
using UnityEngine;
using UnityEngine.UI;

public class SetUserId : MonoBehaviour
{
    public Button loginBtn;

    public TMPro.TMP_InputField field;

    private void Start()
    {
        loginBtn.onClick.AddListener(SetId);
    }

    public void SetId()
    {
        FindObjectOfType<NetworkingManager>().SetNetData(field.text);
    }
}
