using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    public float[] effectRadii;
    public float[] effectStrength;

    public float timer;

    // Use this for initialization
    void Start() {

	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
            doExplode();
	}

    void doExplode()
    {
        for (int i = 0; i < effectRadii.Length; i++)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, effectRadii[i]);
            for (int j = 0; j < hits.Length; j++)
            {
                if(hits[j].GetComponent<Rigidbody>())
                    hits[j].GetComponent<Rigidbody>().AddExplosionForce(i >= effectStrength.Length ? effectStrength[effectStrength.Length - 1] : effectStrength[i], transform.position, effectRadii[i], 3.0f, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }

}
