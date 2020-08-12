using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject[] m_sceneObjects;
    public GameObject m_prevButton;
    public GameObject m_nextButton;
    public GameObject m_initButton;
    public GameObject m_logo;

    private int m_sceneIndex = 0;

    // Start is called before the first frame update
    void Start() {

        //sceneObjects = new GameObject[sceneNum];
        
    }

    public void initScenes() {
        m_prevButton.SetActive(true);
        m_nextButton.SetActive(true);
        m_initButton.SetActive(false);
        m_logo.SetActive(false);
        m_sceneObjects[0].SetActive(true);
    }

    public void switchScenes(bool next) {

        //Debug.Log("Switch scenes triggered. " + next);

        //This will switch out the empty parent objects instansiated in the scene and advance in the array.

        m_sceneObjects[m_sceneIndex].SetActive(false);

        if (next) {
            if (m_sceneIndex < m_sceneObjects.Length - 1) m_sceneIndex++;
        } else {
            if (m_sceneIndex > 0) m_sceneIndex--;
        }

        /*if (next && m_sceneIndex < sceneObjects.Length - 1) m_sceneIndex++;
        else if (m_sceneIndex > 0) m_sceneIndex--;*/

        m_sceneObjects[m_sceneIndex].SetActive(true);

    }


}
