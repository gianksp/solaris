using UnityEngine;
using System.Collections;

public class Perceptible : MonoBehaviour {

	enum Timer { Load, Action };

	[Header("Actionable")]
	public int loadCycleTime		= 10;		//Cycle is 0,1 seconds
	public int actionCycleTime		= 10;		//Cycle is 0,1 seconds
	public bool  repeat 			= false;	//Repeat action after trigger once

	private bool 	_gazedAt;
	private float 	_timer = 0;

	public void ToggleGazeAt() {
		this._gazedAt = !this._gazedAt;
		if (_gazedAt) {
			_timer = loadCycleTime;
			StartCoroutine(DecreaseTimer(Timer.Load));
		} else {
			StopCoroutine(DecreaseTimer(Timer.Load));
		}
	}

	IEnumerator DecreaseTimer(Timer timer) {
		while (_timer > 0) {
			this._timer --;
			yield return new WaitForSeconds(0.1F);
		}

		if (_timer >= 0) {

			if (timer == Timer.Action) {
				Action();
				if (repeat) {
					_timer = actionCycleTime;
					StartCoroutine(DecreaseTimer(Timer.Action));
				}

			} else if (timer == Timer.Load) {
				Debug.Log ("Engaged "+Time.deltaTime);
				_timer = actionCycleTime;
				StartCoroutine(DecreaseTimer(Timer.Action));
			}
		}
	}

	public virtual void Action() {
		Debug.Log ("Action Executed "+Time.deltaTime);

	}
}
