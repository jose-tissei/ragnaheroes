using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData)
    {
		var objectBeingDragged = eventData.pointerDrag.GetComponent<Draggable>();

		if(objectBeingDragged == null) return;

        objectBeingDragged.transform.SetParent(transform);
		objectBeingDragged.Dropped = true;
    }
}
