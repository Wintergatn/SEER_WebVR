using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class ObjectPress : MonoBehaviour
{

    public float m_depth;
    //public GameObject main_camera;
    public CameraDrag m_cam;
    public DiagramAnim m_dia;

    private Vector3 screenPoint;
    private Vector3 offset;

    private Plane plane;
    private bool m_dragging;

    /*public void Press() {
        gameObject.transform.localScale += new Vector3(0, 0, -m_depth);
    }

    public void Release() {
        gameObject.transform.localScale += new Vector3(0, 0, m_depth);
    }*/

    void Start() {
        plane = new Plane(Vector3.forward, Vector3.forward * -1);
    }

    void Update() {
        /*if (m_dragging) {
            Debug.Log("Dragging");
            Ray raycast = new Ray(Input.mousePosition, main_camera.transform.forward);
            if (plane.Raycast(raycast, out float distance)) {
                this.gameObject.transform.position = raycast.GetPoint(distance);
            }
        }*/
    }

    void OnMouseDown() {
        //m_dragging = true;
        m_cam.interacting = true;
        Debug.Log("Pointer down.");

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        
        //StartCoroutine(ScaleCoroutine());
    }

    void OnMouseUp() {
        //m_dragging = false;
        m_cam.interacting = false;
        m_dia.triggerAnimation();
    }

    void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    IEnumerator ScaleCoroutine() {
        float duration = 0.15f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * 1.5f;

        yield return this.AnimateComponent<Transform>(duration, (t, time) =>
        {
            t.localScale = Vector3.Lerp(startScale, endScale, time);
        });
    }
}
