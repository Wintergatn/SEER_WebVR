using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject[] m_sceneObjects;
    public GameObject m_prevButton;
    public GameObject m_nextButton;
    public GameObject m_initButton;
    public GameObject m_tipText;
    public GameObject m_tipImage;
    public GameObject m_logo;

    //These vars are changed externally by other panels when you select them
    public bool m_panel_selected;
    public string m_current_panel_anim;
    public Animator m_panel_animator;
    public GameObject[] textObjects;
    public GameObject[] otherPanels;

    private int m_sceneIndex = 0;

    // Start is called before the first frame update
    void Start() {

        //sceneObjects = new GameObject[sceneNum];
        
    }

    public void initScenes() {
        m_prevButton.SetActive(true);
        m_nextButton.SetActive(true);
        m_initButton.SetActive(false);
        m_tipText.SetActive(false);
        m_tipImage.SetActive(false);
        m_logo.SetActive(false);
        m_sceneObjects[0].SetActive(true);
    }

    public void switchScenes(bool next) {

        

        //Conditional check to see if a panel has been selected
        if (m_panel_selected && !next) {
            reversePanel();
        } else {
            //This will switch out the empty parent objects instansiated in the scene and advance in the array.

            if (m_panel_selected) {
                Debug.Log("Switch scenes triggered. " + next);
                reversePanel();
            }

            m_sceneObjects[m_sceneIndex].SetActive(false);

            if (next) {
                if (m_sceneIndex < m_sceneObjects.Length - 1) m_sceneIndex++;
            } else {
                if (m_sceneIndex > 0) m_sceneIndex--;
            }

            m_sceneObjects[m_sceneIndex].SetActive(true);
        }

    }

    public void reversePanel() {
        m_panel_animator.CrossFade(m_current_panel_anim + "_r", 0.1f);

        for (int i = 0; i < otherPanels.Length; i++) {
            otherPanels[i].SetActive(true);
        }

        for (int i = 0; i < textObjects.Length; i++) textObjects[i].SetActive(false);

        m_panel_selected = false;
    }


}
