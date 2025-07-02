using System.Collections.Generic;
using UnityEngine;

public class ComponentCopier : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject origen;
    public GameObject destino;

    [Header("Prefabs para instanciar como hijos de B")]
    public List<GameObject> prefabsAInstanciar = new List<GameObject>();
}
