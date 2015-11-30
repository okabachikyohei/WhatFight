using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Attack ();
		}
	}

	void Attack () {
		int randomAttack = Random.Range (0, 3);

		switch (randomAttack) {
		case 0:
			anim.SetTrigger("Attack");
			break;
		case 1:
			anim.SetTrigger("AttackLeft");
			break;
		case 2:
			anim.SetTrigger("AttackRight");
			break;
		default:
			break;
		}
	}
}
