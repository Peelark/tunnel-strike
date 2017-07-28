using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    
    public float rate;
    public GameObject projectile;

    private float cooldown;

    

	// Use this for initialization
	void Start () {
        this.cooldown = 1 / this.rate;
	}
	
	// Update is called once per frame
	void Update () {
        this.cooldown -= Time.deltaTime;
	}

    public void Fire() {
        if(this.cooldown < 0)
        {
            Instantiate(projectile, this.transform.position + new Vector3(0f, 0f, 2.5f), this.transform.rotation);
            this.cooldown = 1 / rate;
        }
        
    }
}
