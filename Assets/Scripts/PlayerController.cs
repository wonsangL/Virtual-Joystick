using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Joystick joystick;
    Rigidbody rigidbody;

    Vector2 moveVector;

    public int moveSensitivity = 10;
    
    // Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        moveVector = joystick.inputDir;

        if(moveVector.normalized != Vector2.zero)
        {
            transform.up = moveVector;
        }
        
        rigidbody.AddForce(moveVector * moveSensitivity);
	}
}
