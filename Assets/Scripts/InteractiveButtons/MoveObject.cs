using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public Transform objectToMove;
    bool move = false;
    public Transform camara, worldRoot;

    private void Update()
    {
        if (move)
        {
            objectToMove.SetParent(camara);
        }
        else 
        {
            objectToMove.SetParent(worldRoot);
            
        }
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        move = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        move = false;
    }

    private void OnDisable()
    {
        move = false;
    }

    private void OnEnable()
    {
        move = false;
        objectToMove.localPosition = Vector3.zero;
    }
}
