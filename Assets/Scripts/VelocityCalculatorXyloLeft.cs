using UnityEngine;
using System.Collections;

public class VelocityCalculatorXyloLeft : MonoBehaviour {

	Vector3 velocity;
	Vector3 previous;

	public float velMagLeft;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		velocity = ((transform.position - previous)) / Time.deltaTime;
		previous = transform.position;

		velMagLeft = velocity.magnitude;
	}
}
