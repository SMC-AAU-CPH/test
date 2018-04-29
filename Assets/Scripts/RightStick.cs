using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class RightStick : MonoBehaviour {

	public Vector3 previous;
	public Vector3 velocity;
	public float RightvelMag;

	public int floor_tom_col;
	public int snare_col;
	public int tom1_col;
	public int tom2_col;
	public int cymbal_col;
	public int ride_col;
	public int hihat_col;

	public List<object> rightCol = new List<object> ();

	public int[] elements;


	void Start () {
		rightCol.AddRange (new object[] { floor_tom_col, snare_col, tom1_col, tom2_col, cymbal_col, ride_col, hihat_col, RightvelMag });


		floor_tom_col = 0;
		snare_col = 0;
		tom1_col = 0;
		tom2_col = 0;
		cymbal_col = 0;
		ride_col = 0;
		hihat_col = 0;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "floor_tom") {
			floor_tom_col = 1;
		}
		else if (col.gameObject.tag == "snare") {
			snare_col = 1;
		}
		else if (col.gameObject.tag == "tom1") {
			tom1_col = 1;
		}
		else if (col.gameObject.tag == "tom2") {
			tom2_col = 1;
		}
		else if (col.gameObject.tag == "cymbal") {
			cymbal_col = 1;
		}
		else if (col.gameObject.tag == "ride") {
			ride_col = 1;
		}
		else if (col.gameObject.tag == "hihat") {
			hihat_col = 1;
		}
	}

	void OnTriggerStay(Collider col){
		floor_tom_col = 0;
		snare_col = 0;
		tom1_col = 0;
		tom2_col = 0;
		cymbal_col = 0;
		ride_col = 0;
		hihat_col = 0;
	}

	void OnTriggerExit(Collider col){
		floor_tom_col = 0;
		snare_col = 0;
		tom1_col = 0;
		tom2_col = 0;
		cymbal_col = 0;
		ride_col = 0;
		hihat_col = 0;
	}

	void Update () {
		velocity = ((transform.position - previous)) / Time.deltaTime;
		previous = transform.position;

		RightvelMag = velocity.magnitude;

		//Debug.Log ("RightVelocity :" + RightvelMag);

		rightCol [0] = floor_tom_col;
		rightCol [1] = snare_col;
		rightCol [2] = tom1_col;
		rightCol [3] = tom2_col;
		rightCol [4] = cymbal_col;
		rightCol [5] = ride_col;
		rightCol [6] = hihat_col;
		rightCol [7] = RightvelMag;



		//Debug.Log (rightCol);

		//rightCol.InsertRange (new object[] { floor_tom_col, snare_col, tom1_col, tom2_col, cymbal_col, ride_col, hihat_col, RightvelMag });

	
	}
}
