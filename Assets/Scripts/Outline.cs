using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour {
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    void Start() {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color) {

        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        ClearChildren(outlineObject);
        Renderer rend = outlineObject.GetComponent<Renderer>();
        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineObject.GetComponent<Outline>().enabled = false;
        //outlineObject.GetComponent<Collider>().enabled = false;
        rend.enabled = true;

        return rend;
    }

    public void ClearChildren(GameObject target) {
        int i = 0;
        GameObject[] allChildren = new GameObject[target.transform.childCount];

        foreach (Transform child in target.transform) {
            allChildren[i] = child.gameObject;
            i++;
        }

        foreach (GameObject child in allChildren) {
            DestroyImmediate(child.gameObject);
        }
    }
}