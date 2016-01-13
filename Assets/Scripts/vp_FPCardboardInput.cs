using UnityEngine;
using System.Collections;

public class vp_FPCardboardInput : vp_FPInput {

	public Transform head;
	public GUIStyle guiStyle; //create a new variable

	public float vAccel;
	public float rAccel;
	public float jAccel;

	/// <summary>
	/// move the player forward, backward, left and right
	/// </summary>
	protected override void InputMove()
	{
		
		// NOTE: you could also use 'GetAxis', but that would add smoothing
		// to the input from both Ultimate FPS and from Unity, and might
		// require some tweaking in order not to feel laggy
		float deltaY = Input.gyro.userAcceleration.y;
		if (deltaY <= -0.3f) {
			vAccel = 25.0f;
		} else if (vAccel > 0){
			vAccel-= 1f;
		}
		FPPlayer.InputMoveVector.Set (Vector2.up*vAccel);
	}

	/// <summary>
	/// tell the player to enable or disable the 'Run' state.
	/// NOTE: since running is a state, it's not sent to the
	/// controller code (which doesn't know the state names).
	/// instead, the player class is responsible for feeding the
	/// 'Run' state to every affected component.
	/// </summary>
	protected override void InputRun()
	{

//		float deltaY = Input.gyro.userAcceleration.y;
//		if (deltaY <= -0.5f) {
//			rAccel = 20f;
//		} else if (rAccel > 0){
//			rAccel-= 0.1f;
//		}
//		if (rAccel > 0)
//			FPPlayer.Run.TryStart();
//		else
//			FPPlayer.Run.TryStop();
		
	}
	
	
	/// <summary>
	/// ask controller to jump when button is pressed (the current
	/// controller preset determines jump force).
	/// NOTE: if its 'MotorJumpForceHold' is non-zero, this
	/// also makes the controller accumulate jump force until
	/// button release.
	/// </summary>
	protected override void InputJump()
	{
		
		// TIP: to find out what determines if 'Jump.TryStart'
		// succeeds and where it is hooked up, search the project
		// for 'CanStart_Jump'
		
		float deltaY = Input.gyro.userAcceleration.y;
		if (deltaY <= -1.0f) {
			jAccel = 20f;
		} else if (jAccel > 0){
			jAccel-= 0.1f;
		}
		if (jAccel > 0)
			FPPlayer.Jump.TryStart();
		else
			FPPlayer.Jump.Stop();
		
	}

	void OnGUI(){
		
//		GUI.Label(new Rect(200, 200, 400, 30), Input.gyro.userAcceleration.ToString(),guiStyle);
//		GUI.Label(new Rect(200, 200, 400, 30), Input.gyro.userAcceleration.ToString(),guiStyle);
//		
//		GUI.Label(new Rect(200, 350, 400, 30), "Walk "+vAccel.ToString(),guiStyle);
//		
//		GUI.Label(new Rect(200, 450, 400, 30), "Run "+rAccel.ToString(),guiStyle);
//		
//		GUI.Label(new Rect(200, 550, 400, 30), "Jump "+jAccel.ToString(),guiStyle);
	}
}
