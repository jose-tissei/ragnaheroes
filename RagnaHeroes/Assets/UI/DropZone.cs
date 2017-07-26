using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler {
    public void OnDrop(PointerEventData eventData)
    {
        ForCardIn(eventData, card => card.WasDropped = true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ForCardIn(eventData, card => card.SetDragDestination(transform));
    }

    private void ForCardIn(PointerEventData eventData, Action<ICard> action)
    {
        if(eventData.pointerDrag == null) return;

		var card = eventData.pointerDrag.GetComponent<ICard>();

		if(card == null) return;

        action(card);
    }
}
