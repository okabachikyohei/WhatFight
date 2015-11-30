using UnityEngine;
using System.Collections;

public class UIDirectionControl : MonoBehaviour {

	public bool useRelativeRotation = true;

	private Quaternion relativeRotation;
	
	void Start () {
		relativeRotation = transform.parent.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (useRelativeRotation) {
			transform.rotation = relativeRotation;
		} 
	}
}
