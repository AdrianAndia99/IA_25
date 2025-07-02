using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ComponentCopier))]
public class ComponentCopierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ComponentCopier copier = (ComponentCopier)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Copiar Componentes de A a B"))
        {
            CopiarComponentes(copier.origen, copier.destino);
        }

        if (GUILayout.Button("Eliminar Componentes de B"))
        {
            EliminarComponentes(copier.destino);
        }

        if (GUILayout.Button("Instanciar Prefabs como Hijos de B"))
        {
            InstanciarPrefabsComoHijos(copier.prefabsAInstanciar, copier.destino);
        }
    }

    private void CopiarComponentes(GameObject origen, GameObject destino)
    {
        if (origen == null || destino == null)
        {
            Debug.LogWarning("Asignar ambos GameObjects antes de copiar.");
            return;
        }

        Component[] componentesOrigen = origen.GetComponents<Component>();

        foreach (Component comp in componentesOrigen)
        {
            if (comp is Transform) continue;

            UnityEditorInternal.ComponentUtility.CopyComponent(comp);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(destino);
        }

        Debug.Log($"Componentes copiados de {origen.name} a {destino.name}.");
    }

    private void EliminarComponentes(GameObject destino)
    {
        if (destino == null)
        {
            Debug.LogWarning("Asignar GameObject B antes de eliminar.");
            return;
        }

        Component[] componentes = destino.GetComponents<Component>();
        foreach (Component comp in componentes)
        {
            if (comp is Transform) continue;

            DestroyImmediate(comp);
        }

        Debug.Log($"Componentes eliminados de {destino.name}.");
    }

    private void InstanciarPrefabsComoHijos(List<GameObject> prefabs, GameObject destino)
    {
        if (destino == null)
        {
            Debug.LogWarning("Asignar GameObject B antes de instanciar prefabs.");
            return;
        }

        foreach (GameObject prefab in prefabs)
        {
            if (prefab == null) continue;

            GameObject instancia = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            instancia.transform.SetParent(destino.transform, false);
            instancia.transform.localPosition = Vector3.zero; // Puedes personalizar esto
        }

        Debug.Log($"Instanciados {prefabs.Count} prefabs como hijos de {destino.name}.");
    }
}
