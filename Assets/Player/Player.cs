using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    private Rigidbody rigidBody;
    private Vector3 inputControl;

    public float sensitivity = 3;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        controlPlayer();


    }

    private void controlPlayer()
    {
        inputControl = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0f);
        inputControl = inputControl * sensitivity;
        rigidBody.AddForce(inputControl);
    }
}
