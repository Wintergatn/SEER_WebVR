using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagramAnim : MonoBehaviour
{

    public GameObject text;
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

        //set any text present in the scene to inactive
        text.SetActive(false);
        //StartCoroutine(triggerEvent());
    }

    /*IEnumerator triggerEvent() {
        logo_animator.CrossFade("SEER_Diagram_Popout", 0.1f);
        yield return new WaitForSeconds();
    }*/
}
