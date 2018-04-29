using UnityEngine;
using System.Collections;

public class TransformReset : MonoBehaviour {

	GameObject controller;


	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("ControllerRight");

	
	}


	public void moveReset() {
		gameObject.transform.position = controller.transform.position;
		//stick.transform.Translate (controller.transform.position.x, controller.transform.position.y, controller.transform.position.z);
	}
}
