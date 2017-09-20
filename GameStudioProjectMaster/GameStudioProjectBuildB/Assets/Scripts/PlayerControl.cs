using UnityEngine;
using System.Collections;
using InControl;

public class PlayerControl : MonoBehaviour {

    public float playerSpeed;

    private Rigidbody rigidBody;
    private float xInput;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        InputDevice Controller = InputManager.ActiveDevice;
        xInput = Controller.Direction.X;
	}

    void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(xInput * playerSpeed, rigidBody.velocity.y, rigidBody.velocity.z);
    }
}
