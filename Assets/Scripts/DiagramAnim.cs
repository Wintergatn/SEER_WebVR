using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagramAnim : MonoBehaviour
{

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public Animator logo_animator;

    private bool m_collided;
    private bool m_depressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision other) {
        Debug.Log("collider");
        if (!m_depressed) {
            logo_animator.CrossFade("SEER_Diagram_Depress", 0.1f);
            m_depressed = true;
        }
        
        m_collided = true;
    }

    public void triggerAnimation() {

        logo_animator.CrossFade("SEER_Diagram_Popout", 0.1f);
        //text1.SetActive(true);
        //text2.SetActive(true);
        //text3.SetActive(true);
        //text4.SetActive(true);
        //StartCoroutine(triggerEvent());
    }

    /*IEnumerator triggerEvent() {
        logo_animator.CrossFade("SEER_Diagram_Popout", 0.1f);
        yield return new WaitForSeconds();
    }*/
}
