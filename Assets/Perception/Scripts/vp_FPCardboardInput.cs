using UnityEngine;
using System.Collections;

public class vp_FPCardboardInput : vp_FPInput {

	/// <summary>
	/// move the player forward, backward, left and right
	/// </summary>
	protected override void InputMove()
	{
		
		// NOTE: you could also use 'GetAxis', but that would add smoothing
		// to the input from both Ultimate FPS and from Unity, and might
		// require some tweaking in order not to feel laggy
		float anglex = Cardboard.SDK.HeadPose.Orientation.eulerAngles.x;
		float anglez = Cardboard.SDK.HeadPose.Orientation.eulerAngles.z;
		float angley = Cardboard.SDK.HeadPose.Orientation.eulerAngles.y;
		anglex = (anglex > 180) ? anglex - 360 : anglex;
		anglez = (anglez > 180) ? anglez - 360 : anglez;
		FPPlayer.InputMoveVector.Set (Vector2.up * anglex/20f+Vector2.left*anglez/50f);
	
		//Rotate around Y to adjust 
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, angley, transform.eulerAngles.z);
	}

	protected override Vector2 GetMouseLook()
	{
		return Vector2.zero;
	}
}
