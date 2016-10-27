using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {
    public bool fromCenter;
    public bool inverse;
    public Vector3 forceEffect;
    public float strength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerStay(Collider other)
    {
        Vector3 dir = forceEffect.normalized;
        if(other.attachedRigidbody && other.tag == "Respawn")
        {
            if(fromCenter)
            {
                dir = (other.transform.position - transform.position).normalized;
            }
            if(inverse)
            {
                dir = -dir;
            }

            other.attachedRigidbody.AddForce(dir * strength, ForceMode.Force);
        }
    }
}
