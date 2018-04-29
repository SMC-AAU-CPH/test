using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LeftStick : MonoBehaviour {

	public Vector3 previous;
	public Vector3 velocity;
	public float LeftvelMag;

	public int floor_tom_col;
	public int snare_col;
	public int high_tom_col;
	public int mid_tom_col;
	public int crash_col;
	public int crash2_col;
	public int high_hat_col;

	List<object> leftCol = new List<object> ();

	void Start () {
		
		leftCol.AddRange (new object[] { floor_tom_col, snare_col, high_tom_col, mid_tom_col, crash_col, crash2_col, high_hat_col, LeftvelMag });


		floor_tom_col = 0;
		snare_col = 0;
        high_tom_col = 0;
        mid_tom_col = 0;
        crash_col = 0;
        crash2_col = 0;
        high_hat_col = 0;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "floor_tom") {
			floor_tom_col = 1;
		}
		else if (col.gameObject.tag == "snare") {
			snare_col = 1;
		}
		else if (col.gameObject.tag == "high_tom") {
            high_tom_col = 1;
		}
		else if (col.gameObject.tag == "tom2") {
            mid_tom_col = 1;
		}
		else if (col.gameObject.tag == "cymbal") {
			crash_col = 1;
		}
		else if (col.gameObject.tag == "ride") {
            crash2_col = 1;
		}
		else if (col.gameObject.tag == "hihat") {
            high_hat_col = 1;
		}
	}

	void OnTriggerStay(Collider col){
		floor_tom_col = 0;
		snare_col = 0;
        high_tom_col = 0;
        mid_tom_col = 0;
        crash_col = 0;
        crash2_col = 0;
        high_hat_col = 0;
	}

	void OnTriggerExit(Collider col){
		floor_tom_col = 0;
		snare_col = 0;
        high_tom_col = 0;
        mid_tom_col = 0;
        crash_col = 0;
        crash2_col = 0;
        high_hat_col = 0;
	}

	void Update () {
		velocity = ((transform.position - previous)) / Time.deltaTime;
		previous = transform.position;

		LeftvelMag = velocity.magnitude;




		leftCol [0] = floor_tom_col;
		leftCol [1] = snare_col;
		leftCol [2] = high_tom_col;
		leftCol [3] = mid_tom_col;
		leftCol [4] = crash_col;
		leftCol [5] = crash2_col;
		leftCol [6] = high_hat_col;
		leftCol [7] = LeftvelMag;



		//Debug.Log ("LeftVelocity :" + LeftvelMag);

	


	}
}
