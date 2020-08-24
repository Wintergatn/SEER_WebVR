using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderQueue : MonoBehaviour
{
    public int m_renderQueueValue;

    // Start is called before the first frame update
    void Start()
    {
        Material m_material = GetComponent<Renderer>().material;
        m_material.renderQueue = m_renderQueueValue;

        Debug.Log("Render queue: " + m_material.renderQueue);
    }
}
