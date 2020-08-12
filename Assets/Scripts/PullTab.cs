using System.Collections;
using UnityEngine;

public class PullTab : MonoBehaviour
{

    /*bool m_dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("HEELLLO");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("Tab clicked.");
        m_dragging = true;

        //float increment_dist = (Input.mousePosition.y - transform.position.y) / 5;
        //Vector3 pos = transform.position;
        //pos.y += increment_dist;
        //transform.position = pos;

        //transform.Translate(Vector3.up * increment_dist, Space.World);

        //Vector3 lerpPos = Vector3.Lerp(transform.position, Input.mousePosition, );
        //transform.position
    }*/

    public CameraDrag m_cam;
    public GameObject m_parent;
    public GameObject cloud_panels;
    public GameObject side_objects;
    public float max_distance;
    public float pulltabWait = 1.0f;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 origPos;
    private Vector3 max_pos;
    private Vector3 parent_pos;

    private Vector3 start_pos;
    private Vector3 cur_pos;

    private Animator cloud_animator;
    private Animator panels_animator;

    private float speed = 1.0f;
    

    void Start() {
        
        origPos = transform.position;

        parent_pos = m_parent.transform.position;
        parent_pos.y -= max_distance;
        max_pos = parent_pos;

        cloud_animator = m_parent.GetComponent<Animator>();
        panels_animator = cloud_panels.GetComponent<Animator>();
    }

    void OnMouseDown() {
        m_cam.interacting = true;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        start_pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Debug.Log("Mouse Start Position : " + start_pos);
    }

    void OnMouseUp() {
        m_cam.interacting = false;
        /*float distLength = Vector3.Distance(transform.position, origPos);
        float startTime = Time.time;

        while (transform.position != origPos) {
            float distCovered = (Time.time - startTime) * speed;
            float frac = distCovered / distLength;
            transform.position = Vector3.Lerp(transform.position, origPos, frac);
        }*/
    }

    void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        Vector3 pos = transform.position;
        pos.y = curPosition.y;

        cur_pos = Camera.main.ScreenToWorldPoint(curScreenPoint);
        //Debug.Log("Mouse End Position : " + cur_pos);
        float distance = Vector3.Distance(start_pos, curPosition);
        //Debug.Log("Mouse Distance : " + distance);
        if (distance >= max_distance) {
            StartCoroutine(triggerEvent());
        }
        transform.position = pos;
        /*
        Debug.Log("is true?: " + (pos.y - parent_pos.y > max_distance) + "and diff: " + (pos.y - parent_pos.y));

        //if (Mathf.Abs(pos.y - parent_pos.y) > max_distance) transform.position = max_pos;
        if (Vector3.Distance(pos, parent_pos) > max_distance) transform.position = max_pos;
        else transform.position = pos;
        
        //transform.position = curPosition;
        */
    }

    IEnumerator triggerEvent() {

        //somehow clamp to threshold
        Debug.Log("threshold");
        side_objects.SetActive(false);
        //cloud_animator.Play("Tab");
        cloud_animator.CrossFade("Tab", 0.1f);
        //wait

        cloud_panels.SetActive(true);
        //panels_animator.Play("Cloud_Panels");
        panels_animator.CrossFade("Cloud_Panels", 0.1f);

        yield return new WaitForSeconds(pulltabWait);
        this.gameObject.SetActive(false);
    }
}
