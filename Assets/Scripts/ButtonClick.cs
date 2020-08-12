using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SceneEvent : UnityEvent<bool> {

}

public class ButtonClick : MonoBehaviour {
    
    public SceneEvent m_switchScenesEvent;
    public CameraDrag m_cam;
    public float m_depth;

    //invokeNext is set in editor, determines whether the button invokes the next button event or the previous button event
    public bool invokeNext;

    public Material m_highlightMat;
    public Material m_greyedMat;
    private Material m_defaultMat;

    // Start is called before the first frame update
    void Start() {
        if (m_switchScenesEvent == null) m_switchScenesEvent = new SceneEvent();
        m_defaultMat = GetComponent<Renderer>().material;

        //m_switchScenesEvent.AddListener(Ping);
    }

    void OnMouseOver() {
        GetComponent<Renderer>().material = m_highlightMat;
    }

    void OnMouseExit() {
        GetComponent<Renderer>().material = m_defaultMat;
    }

    void OnMouseDown() {
        gameObject.transform.localScale += new Vector3(0, 0, m_depth);
        //if (m_switchScenesEvent != null) 
        if (this.tag != "init") {
            m_cam.interacting = true;
            //Debug.Log("interacting.");
        }
        
    }

    void OnMouseUp() {
        gameObject.transform.localScale += new Vector3(0, 0, -m_depth);
        m_switchScenesEvent.Invoke(invokeNext);
        m_cam.interacting = false;
    }

    /*void Ping(bool test) {
        Debug.Log("Event triggered. " + test);
    }*/

}
