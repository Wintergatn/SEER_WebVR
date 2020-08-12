using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{

    public float speed = 3.5f;
    public bool interacting = false;
    private float m_camx;
    private float m_camy;

    void Update() {

        if (Input.GetMouseButton(0) && !interacting) {

            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            m_camx = transform.rotation.eulerAngles.x;
            m_camy = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(m_camx, m_camy, 0);

        }

        if (Input.GetMouseButtonUp(0)) interacting = false;
    }

}
