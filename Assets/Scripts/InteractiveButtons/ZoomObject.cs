using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomObject : MonoBehaviour
{
    public float zoomValue;

    public Transform objectToZoom;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(zoom);
    }

    void zoom()
    {
        if (zoomValue < 0)
        {
            objectToZoom.localScale = objectToZoom.localScale + (Vector3.one * zoomValue);            
        }
            
        if (zoomValue > 0)
        {
            objectToZoom.localScale = objectToZoom.localScale + (Vector3.one * zoomValue);            
        }
            
    }

    private void OnEnable()
    {
        objectToZoom.localScale = Vector3.one;
    }
}
