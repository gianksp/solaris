using UnityEngine;
using System.Collections;

public class SensorController : MonoBehaviour {

	public Transform motorSensor;


	private float acceleration = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Forward/Backwards
		acceleration = -motorSensor.forward.y*10f;


		transform.Translate (Vector3.forward*acceleration * Time.deltaTime);

		float angleY = Mathf.LerpAngle(transform.eulerAngles.y, motorSensor.eulerAngles.y, Time.deltaTime*3f);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, angleY, transform.eulerAngles.z);
	}


	void OnGUI(){
		GUI.Label(new Rect(90, 90, 300, 20), "Rot Accel = "+transform.localEulerAngles);
		GUI.Label(new Rect(90, 110, 300, 20), "Rot Rate = "+motorSensor.localEulerAngles);
		GUI.Label(new Rect(90, 130, 300, 20), "angle = "+ motorSensor.forward.y);
		
		GUI.Label(new Rect(90, 150, 300, 20), "Accel magnitude = "+Input.acceleration.magnitude);
		GUI.Label(new Rect(90, 170, 300, 20), "Accel = "+Input.acceleration);
		GUI.Label(new Rect(90, 270, 300, 20), "Rotation = "+motorSensor.rotation.x);
	}
}
