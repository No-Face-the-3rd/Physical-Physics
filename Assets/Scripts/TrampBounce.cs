using UnityEngine;
using System.Collections;

public class TrampBounce : MonoBehaviour {
    public float bounceStrength;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody)
            collision.rigidbody.AddForce((transform.rotation * Vector3.up) * bounceStrength * collision.rigidbody.mass, ForceMode.Impulse);
    }
}
