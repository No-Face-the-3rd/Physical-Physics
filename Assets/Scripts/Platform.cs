using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

    public Vector3[] waypoints;
    public bool loop = false;
    public bool reverse = true;
    public float speed;

    private int target = 0;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity.magnitude > speed)
            rb.velocity = rb.velocity.normalized * speed;
        Vector3 dir = waypoints[target] - transform.position;
        Vector3 force = dir.normalized * speed;
        rb.AddForce(force, ForceMode.VelocityChange);

        if(dir.magnitude < 0.5f)
        {
            if(!loop)
            {
                if(target == 0 || target % (waypoints.Length - 1) == 0)
                {
                    reverse = !reverse;
                }
            }
            target = reverse ? (target - 1) % waypoints.Length : (target + 1) % waypoints.Length;
            if (target < 0)
                target += waypoints.Length;
        }
	}
}
