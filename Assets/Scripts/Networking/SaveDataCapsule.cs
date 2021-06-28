
using UnityEngine;
using UnityEngine.UI;

public class SaveDataCapsule : MonoBehaviour
{
    Button button;
    public string capsule, microcapsule;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SaveData);
    }

    void SaveData()
    {
        FindObjectOfType<NetworkingManager>().SetNetDataButton(capsule, microcapsule);
    }
}
