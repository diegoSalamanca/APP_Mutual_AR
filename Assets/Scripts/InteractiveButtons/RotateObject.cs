using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float rotateAngle;

    public Transform objectToRotate;

    Button button;

    bool rot = false;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        //button.onClick.AddListener(Rotate);
    }

    private void Update()
    {
        if (rot)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        objectToRotate.RotateAround(objectToRotate.position, Vector3.up, rotateAngle*Time.deltaTime);
    }

    private void OnEnable()
    {
        objectToRotate.rotation = Quaternion.Euler(Vector3.zero);
        rot = false;
    }

    private void OnDisable()
    {
        rot = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rot = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rot = true;
    }
}
