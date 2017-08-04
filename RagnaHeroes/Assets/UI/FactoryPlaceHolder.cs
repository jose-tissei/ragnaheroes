using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryPlaceHolder : IFactoryPlaceHolder 
{

	public GameObject CreatePlaceHolder(MonoBehaviour gameObject)
    {
        var placeHolder = new GameObject{ name = "Card Place Holder" };
        var gameObjectLayout = gameObject.GetComponent<LayoutElement>();
        var placeHolderLayout = placeHolder.AddComponent<LayoutElement>();

        placeHolderLayout.preferredWidth = gameObjectLayout.preferredWidth;
        placeHolderLayout.preferredHeight = gameObjectLayout.preferredHeight;
        placeHolder.transform.SetParent(gameObjectLayout.transform.parent);
		placeHolder.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex());

        return placeHolder;
    }
}
