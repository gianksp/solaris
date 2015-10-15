﻿using UnityEngine;
using System.Collections;

public class SensorController : MonoBehaviour {

	public Transform motorSensor;

	private float targetAccel  = 0;
	private float acceleration = 0;

	private float hAccel = 0;
	private float angleY = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Forward/Backwards
		targetAccel = -motorSensor.forward.y*Mathf.Exp(2);
		hAccel = -motorSensor.right.y * Mathf.Exp (2);

		if (targetAccel <= -4f) {
			targetAccel *= 0.3f;
		} else if (targetAccel <= 1.5f) {
			targetAccel *= 0f;
		} else if (targetAccel <= 2.25f) {
			targetAccel *= 0.3f;
		} else if (targetAccel <= 3f) {
			targetAccel *= 0.6f;
		} else {
			targetAccel *= 1.0f;
		}

		acceleration = Mathf.Lerp (acceleration, targetAccel, Time.time*0.1f);

		//Rotate body to follow neck twist
		angleY = Mathf.LerpAngle(transform.eulerAngles.y, motorSensor.eulerAngles.y, Time.deltaTime*3f);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleY, transform.eulerAngles.z);

		//Move towards the head balance
		transform.Translate ((Vector3.right*hAccel+Vector3.forward*acceleration) * Time.deltaTime);

	}


	void OnGUI(){
		GUI.Label(new Rect(90, 90, 300, 20), "Rot Accel = "+motorSensor.eulerAngles);
		GUI.Label(new Rect(90, 110, 300, 20), "Rot Rate z = "+-motorSensor.eulerAngles.z);
		GUI.Label(new Rect(90, 130, 300, 20), "angle = "+ -motorSensor.forward.y*Mathf.Exp(2)/2);
		
		GUI.Label(new Rect(90, 150, 300, 20), "Accel magnitude = "+Input.acceleration.magnitude);
		GUI.Label(new Rect(90, 170, 300, 20), "H accel = "+hAccel);
		GUI.Label(new Rect(90, 270, 300, 20), "Angle = "+Vector3.Angle(Vector3.forward, motorSensor.right));
	}
}
