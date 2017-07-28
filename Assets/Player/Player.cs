using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody rigidBody;
    private Vector3 inputControl;

    public float sensitivity = 3;
    public Weapon mainWeapon;
    public Weapon secondWeapon;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMovement();
        PlayerWeapons();

    }

    private void PlayerMovement()
    {
        if (WithinBounds())
        {
            ControlPlayer();
        }
        else
        {
            RegulatePlayer();
        }
    }

    private void ControlPlayer()
    {
        inputControl = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0f);
        inputControl = inputControl * sensitivity;

        rigidBody.AddForce(inputControl);
        rigidBody.AddTorque(new Vector3(0f, 0f, -0.5f*inputControl.x));
                    
        int dir = rigidBody.rotation.eulerAngles.z > 180 ? -1 : 1;
        Vector3 stabiliser = new Vector3(0f, 0f, dir*10*((transform.up.y-1)));
        rigidBody.AddTorque(stabiliser);
        
    }

    private bool WithinBounds()
    {
        Vector3 currentPos = rigidBody.transform.position;
        if (Mathf.Abs(currentPos.x) > 10 || Mathf.Abs(currentPos.y) > 8) {
            return false;
        }
        return true;
    }

    private void RegulatePlayer() {
        rigidBody.AddForce((new Vector3(0f,0f,0f) - transform.position)*10);
    }

    private void PlayerWeapons() {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            mainWeapon.Fire();
        }
        if (CrossPlatformInputManager.GetButton("Fire2"))
        {
            secondWeapon.Fire();
        }
    }
}
