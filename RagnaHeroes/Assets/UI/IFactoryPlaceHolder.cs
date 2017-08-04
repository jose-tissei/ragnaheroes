using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactoryPlaceHolder 
{
    GameObject CreatePlaceHolder(MonoBehaviour gameObject);
}
