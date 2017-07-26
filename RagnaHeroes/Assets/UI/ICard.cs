using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public interface ICard : IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	bool WasDropped {get;set;}
	void SetDragDestination(Transform destination);
	Transform GetDragOrigin();
}
