using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool Dropped {get;set;}

    public void OnBeginDrag(PointerEventData eventData)
    {
        //TODO: store as an difference transform.position - eventData.position 
		//to make the drag event less clunky

        transform.SetParent(GameObject.Find("Canvas").GetComponent<Canvas>().transform);
        Dropped = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(Dropped) return;

        transform.SetParent(GameObject.Find("Hand").GetComponent<Image>().transform);
    }
}
