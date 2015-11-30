using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 8f;
	public float turnSpeed = 100f;

	private Animator anim;
	private Rigidbody playerRigidbody;
	private float movementInputValue;
	private float turnInputValue;
	
	void Awake () {
		playerRigidbody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void OnEnable () {
		// When the player is turned on, make sure it's not kinematic.
		playerRigidbody.isKinematic = false;

		movementInputValue = 0f;
		turnInputValue = 0f;
	}

	void OnDisable () {
		// When the player is turned off, set it to kinematic so it stops moving.
		playerRigidbody.isKinematic = false;
	}

	void Update () {
		movementInputValue = Input.GetAxis ("Vertical");
		turnInputValue = Input.GetAxis ("Horizontal");

		MovingAnimation ();
	}

	void FixedUpdate () {
		Move ();
		Turn ();
	}

	void Move () {
		Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
		playerRigidbody.MovePosition (playerRigidbody.position + movement);
	}

	void Turn () {
		float turn = turnInputValue * turnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		playerRigidbody.MoveRotation (playerRigidbody.rotation * turnRotation);
	}

	void MovingAnimation () {
		bool isWalking = movementInputValue != 0f || turnInputValue != 0f;
		anim.SetBool ("Walking", isWalking);
	}
}
