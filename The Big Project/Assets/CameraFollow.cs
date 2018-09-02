using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform carTransform;
    Vector3 range;
	// Use this for initialization
    void Awake () {
        range = transform.position - carTransform.position;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(range.x + carTransform.position.x, transform.position.y, range.z + carTransform.position.z);
		
}
}
