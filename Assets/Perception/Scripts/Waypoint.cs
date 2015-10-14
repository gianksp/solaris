using UnityEngine;
using System.Collections;

public class Waypoint : Perceptible {

	public Transform player;

	public override void Action() {
		Debug.Log ("Action Override "+Time.deltaTime);
	}

}
