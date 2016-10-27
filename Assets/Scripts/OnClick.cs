using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {
    public float strength;
    public Vector3 moveDir;
    public float distance;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distance))
            {
                if(hit.collider.gameObject.tag == "Respawn")
                hit.collider.GetComponent<Rigidbody>().AddForce(moveDir * strength * hit.collider.GetComponent<Rigidbody>().mass, ForceMode.Impulse);
            }
        }
	}
}
