using UnityEngine;
using System.Collections;
#if UNITY_ANDROID && !UNITY_EDITOR
using tv.ouya.console.api;
#endif

public class PlayerControlOuya : MonoBehaviour {

	public int playerNumber;
	public float speed = 10;
	#if UNITY_ANDROID && !UNITY_EDITOR
	Vector2 v2 = new Vector2 (0,0);
	#endif

	GUIStyle smallFont;
	GUIStyle largeFont;

	Rigidbody2D rb;
	
	// Use this for initialization
	void Start ()
	{
		smallFont = new GUIStyle();
		largeFont = new GUIStyle();
		
		smallFont.fontSize = 10;
		largeFont.fontSize = 32;

		rb = GetComponent<Rigidbody2D>();
	}
	/**
	#if UNITY_ANDROID && !UNITY_EDITOR
	private bool GetButton_DPAD_Up()
	{
		return OuyaSDK.OuyaInput.GetButton (playerNumber, OuyaController.BUTTON_DPAD_UP);

	}

	private bool GetButton_DPAD_Down()
	{
		return OuyaSDK.OuyaInput.GetButton (playerNumber, OuyaController.BUTTON_DPAD_DOWN);
	}
	#endif
*/

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (OuyaSDK.OuyaInput.GetButton (playerNumber, OuyaController.BUTTON_DPAD_UP))
		{
			rb.velocity = new Vector2(0, speed);
//			v2.y = speed;
//			rigidbody.velocity = v2;
		}
		else if (OuyaSDK.OuyaInput.GetButton (playerNumber, OuyaController.BUTTON_DPAD_DOWN))
		{
			rb.velocity = new Vector2(0, speed * -1);
//			v2.y = speed * -1;
//			rigidbody.velocity = v2;
		}
		else if(OuyaSDK.OuyaInput.GetAxisRaw(playerNumber, OuyaController.AXIS_LS_Y) < -0.2)
		{
			rb.velocity = new Vector2(0, speed);
		}
		else if(OuyaSDK.OuyaInput.GetAxisRaw(playerNumber, OuyaController.AXIS_LS_Y) > 0.2)
		{
			rb.velocity = new Vector2(0, speed * -1);
		}
		else if(OuyaSDK.OuyaInput.GetAxisRaw(playerNumber, OuyaController.AXIS_LS_Y) < 0.2 && 
		        OuyaSDK.OuyaInput.GetAxis(playerNumber, OuyaController.AXIS_LS_Y) > -0.2)
		{
			rb.velocity = new Vector2(0, 0);
		}
//		else //if(OuyaSDK.OuyaInput.GetButtonUp(playerNumber, OuyaController.BUTTON_DPAD_UP) || OuyaSDK.OuyaInput.GetButtonUp(playerNumber, OuyaController.BUTTON_DPAD_DOWN))
//		{
//				rb.velocity = new Vector2(0, 0);
////			v2.y = 0;
////			GetComponent<Rigidbody2D>.velocity = v2;
//		}
//			rb.velocity = new Vector2(0, 0);	
////		v2.x = 0;
////		rb.velocity = v2;
		#endif
	}
/**
	void OnGUI()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (Debug.isDebugBuild)
		{
			if(playerNumber == 0)
			{
				GUILayout.Label ("<color=white>Player 1</color>", largeFont);
				GUILayout.Label ("<color=white>v2 = " + v2 + "</color>", largeFont);
				GUILayout.Label ("<color=white>velocity = " + GetComponent<Rigidbody2D>.velocity.y + "</color>", largeFont);
				GUILayout.Label ("<color=white>Left Stick - Control 1 = " + 
			                 OuyaSDK.OuyaInput.GetAxis(0, OuyaController.AXIS_LS_Y) + 
			                 "</color>", largeFont);
			
			}

			if(playerNumber == 1)
			{
				GUILayout.Label ("\n \n \n \n", largeFont);
				GUILayout.Label ("<color=white>Player 2</color>", largeFont);
				GUILayout.Label ("<color=white>v2 = " + v2 + "</color>", largeFont);
				GUILayout.Label ("<color=white>velocity = " + GetComponent<Rigidbody2D>.velocity.y + "</color>", largeFont);
				GUILayout.Label ("<color=white>Left Stick - Control 2 = " + 
			                 OuyaSDK.OuyaInput.GetAxis(1, OuyaController.AXIS_LS_Y) + 
			                 "</color>", largeFont);
			}
		}
		#endif
	}
**/
}

