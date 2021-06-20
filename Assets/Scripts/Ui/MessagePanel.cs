
using UnityEngine;


public class MessagePanel : MonoBehaviour
{

    public TMPro.TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        iTween.ScaleFrom(gameObject, Vector3.zero, 0.5f);
    }

    public void SetMessage(string message)
    {
        textMesh.text = message;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
    
}
