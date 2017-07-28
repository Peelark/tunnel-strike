using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody rigidBody;
    public float fireVelocity;
    public float damage;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0f, 0f, fireVelocity);
        print("will do " + damage);
	}
	
	// Update is called once per frame
	void Update () {
		if(this.rigidBody.position.z > 100)
        {
            this.Die();
        }
	}

    void Die() {
        DestroyObject(this.gameObject);
    }
}
