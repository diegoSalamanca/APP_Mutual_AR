
using UnityEngine;
using UnityEngine.UI;
using easyar;

public class ArController : MonoBehaviour
{
    public ARSession session;

    public Button TrackerButton;

    public GameObject AreaButton, interactiveButtons, ParentModels;

    public GameObject[] Models;

    public Button[] buttonsSlider;

    public Transform sceneObjects;

    ARSoundsController arSoundsController;

    SurfaceTrackerFrameFilter tracker;

    // Start is called before the first frame update
    void Awake()
    {
        interactiveButtons.SetActive(false);
        tracker = session.GetComponentInChildren<SurfaceTrackerFrameFilter>();
        tracker.enabled = false;
        TrackerButton.onClick.AddListener(Starttracker);
        ParentModels.SetActive(false);
    }

    private void Start()
    {
        arSoundsController = GetComponent<ARSoundsController>();
        DisableAndamios();
    }

    public void Starttracker()
    {
        tracker.enabled = true;
        AreaButton.SetActive(false);
        interactiveButtons.SetActive(true);
        EnableAndamiosIndex(0);
        EnableButtons();
    }

    private void OnEnable()
    {
        AreaButton.SetActive(true);
        interactiveButtons.SetActive(false);
        DisableButtons();
        DisableAndamios();
        ParentModels.SetActive(true);
    }

    private void OnDisable()
    {
        if(tracker)
            tracker.enabled = false;

        DisableButtons();

        if(ParentModels)
            ParentModels.SetActive(false);
    }

    public void DisableAndamios()
    {
        foreach (var item in Models)
        {
            item.SetActive(false);
        }
    }

    public void EnableAndamiosIndex(int index)
    {
        DisableAndamios();
        Models[index].SetActive(true);        
        sceneObjects.localScale = Vector3.one;
        sceneObjects.rotation = Quaternion.Euler(Vector3.zero);

        arSoundsController.PlayAuido(index);


    }

    void DisableButtons()
    {
        foreach (var item in buttonsSlider)
        {
            item.interactable = false;
        }
    }

    void EnableButtons()
    {
        foreach (var item in buttonsSlider)
        {
            item.interactable = true;
        }
    }

}
