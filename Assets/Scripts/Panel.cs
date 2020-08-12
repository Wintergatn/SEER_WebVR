using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Animator panel_animator;
    public GameObject[] m_textObjects;
    public GameObject[] m_otherPanels;
    public string select_animation_name;

    private bool revealed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void revealPanel() {
        //animation
        panel_animator.CrossFade(select_animation_name, 0.1f);

        //temp, will change to animation
        for (int i = 0; i < m_otherPanels.Length; i++) {
            m_otherPanels[i].SetActive(false);
        }

        //reveal text
        for (int i = 0; i < m_textObjects.Length; i++) m_textObjects[i].SetActive(true);
    }
}
