using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class Draggable : MonoBehaviour, ICard
{
    private readonly IFactoryPlaceHolder factoryPlaceHolder;
    
    [Inject(Id = "SceneCanvas")]
    public readonly Canvas sceneCanvas;
    private GameObject placeHolder;
    private Transform dragOrigin;
    private Transform dragDestination;
    public bool WasDropped {get;set;}

    public Draggable(IFactoryPlaceHolder factoryPlaceHolder, Canvas sceneCanvas)
    {
        this.factoryPlaceHolder = factoryPlaceHolder;
        this.sceneCanvas = sceneCanvas;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //TODO: store as an difference transform.position - eventData.position 
		//to make the drag event less clunky

        dragOrigin = transform.parent;
        placeHolder = factoryPlaceHolder.CreatePlaceHolder(this);
        
        transform.SetParent(sceneCanvas.transform);
        WasDropped = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        var placeHolderParent = placeHolder.transform.parent;
        var placeHolderIndex = placeHolderParent.transform.childCount;

        for(var i = 0; i < placeHolderParent.transform.childCount; i++)
        {
            var child = placeHolderParent.transform.GetChild(i);

            if(transform.position.x >= child.position.x) continue;

            var childIndex = child.transform.GetSiblingIndex();

            placeHolderIndex =
                placeHolder.transform.GetSiblingIndex() < childIndex
                ? childIndex - 1
                : childIndex;

            break;
        }

        placeHolder.transform.SetSiblingIndex(placeHolderIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.SetParent(WasDropped ? dragDestination : dragOrigin);

        Destroy(placeHolder);
    }

    public void SetDragDestination(Transform destination)
    {
        dragDestination = destination;
        placeHolder.transform.SetParent(destination);
    }

    public Transform GetDragOrigin()
    {
        return dragOrigin;
    }
}
