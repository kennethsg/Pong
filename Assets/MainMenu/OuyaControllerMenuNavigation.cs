using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System;
#if UNITY_ANDROID && !UNITY_EDITOR
using tv.ouya.console.api;
#endif

public class OuyaControllerMenuNavigation : MonoBehaviour
{
	private MoveDirection moveDir;
	private string testString;
	//private bool isInputBlocked = false;
	private DateTime detected;

	// Use this for initialization
	void Start ()
	{
		testString = "";
		/**
		Navigation customNav = new Navigation();
		customNav.mode = Navigation.Mode.Explicit;
		customNav.selectOnDown = this.GetComponentInParent.Creditsbutton;
		_myObject.navigation = customNav;
		**/
	}

	// Update is called once per frame
	public void Update () 
	{
//		EventSystem.current.sendNavigationEvents = MoveDirection.Up;
		/**
		ExecuteEvents.Execute (
			EventSystem.current, 
			EventSystem.current.currentSelectedGameObject, 
			ExecuteEvents.moveHandler);
		**/
//		EventSystem.current.gameObject.name;


		#if UNITY_ANDROID && !UNITY_EDITOR
		if ((detected < DateTime.Now && GetAxisRaw(OuyaController.AXIS_LS_Y, -0.2)) ||
		    GetButtonDown(OuyaController.BUTTON_DPAD_UP))
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().FindSelectableOnUp().Select();
			detected = DateTime.Now + TimeSpan.FromSeconds(0.33f); //ignore input for a period of time in seconds
			//isInputBlocked = true;
			//StartCoroutine(Wait(0.33f));

		}
		else if ((detected < DateTime.Now && GetAxisRaw(OuyaController.AXIS_LS_Y, 0.2)) ||
		         GetButtonDown(OuyaController.BUTTON_DPAD_DOWN))
		{
			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().FindSelectableOnDown().Select();
			detected = DateTime.Now + TimeSpan.FromSeconds(0.33f); //ignore input for a period of time in seconds
			//isInputBlocked = true;
			//StartCoroutine(Wait(0.33f));
		}

		if(GetButtonDown(OuyaController.BUTTON_O))
		{ 
//			ExecuteEvents.Execute<ISubmitHandler>(EventSystem.current.currentSelectedGameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
			SendSubmitEventToSelectedObject();
		}		
		#endif



		/**
		if (Input.GetButton ("Play"))
			testString = "Play Button Was Pressed";
**/
	}

	//Sends a Submit Event
	private bool SendSubmitEventToSelectedObject()  
	{
		bool isEventSubmitted = false;
		
		if (EventSystem.current.currentSelectedGameObject != null) 
		{
			ExecuteEvents.Execute<ISubmitHandler> (EventSystem.current.currentSelectedGameObject,
			                                       new BaseEventData (EventSystem.current), 
			                                       ExecuteEvents.submitHandler);
			isEventSubmitted = true;
		}
		return isEventSubmitted;
	}


	//Receives any Ouya controller button as parameter and
	//returns true if that button is pressed by any player controller
	public bool GetButtonDown(int OuyaButton)
	{
		bool isKeyPressed = false;

		#if UNITY_ANDROID && !UNITY_EDITOR
		if(OuyaSDK.OuyaInput.GetButtonDown (0, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonDown (1, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonDown (2, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonDown (3, OuyaButton))
			isKeyPressed = true;
		#endif

		return isKeyPressed;
	}

	public bool GetButtonUp(int OuyaButton)
	{
		bool isKeyPressed = false;
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(OuyaSDK.OuyaInput.GetButtonUp (0, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonUp (1, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonUp (2, OuyaButton) ||
		   OuyaSDK.OuyaInput.GetButtonUp (3, OuyaButton))
			isKeyPressed = true;
		#endif
		
		return isKeyPressed;
	}

	//If sensitivity is negative returns true when axis value is less than sensitivity.
	//If sensitivity is positive returns true when axis value is more than sensitivity.
	public bool GetAxisRaw(int OuyaAxis, double sensitivity)
	{
		bool isAxisMoved = false;

		#if UNITY_ANDROID && !UNITY_EDITOR
		if (sensitivity > 0)
			isAxisMoved = GetAxisRawMoreThan(OuyaAxis, sensitivity);
		else if(sensitivity < 0)
			isAxisMoved = GetAxisRawLessThan(OuyaAxis, sensitivity);
		#endif

		return isAxisMoved;
	}

	//Returns true if axis value is less than sensitivity
	private bool GetAxisRawLessThan(int OuyaAxis, double sensitivity)
	{
		bool isAxisMoved = false;
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(OuyaSDK.OuyaInput.GetAxisRaw(0, OuyaAxis) < sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(1, OuyaAxis) < sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(2, OuyaAxis) < sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(3, OuyaAxis) < sensitivity)
			isAxisMoved = true;
		#endif

		return isAxisMoved;
	}

	//Returns true if axis value is more than sensitivity
	private bool GetAxisRawMoreThan(int OuyaAxis, double sensitivity)
	{
		bool isAxisMoved = false;

		#if UNITY_ANDROID && !UNITY_EDITOR
		if(OuyaSDK.OuyaInput.GetAxisRaw(0, OuyaAxis) > sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(1, OuyaAxis) > sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(2, OuyaAxis) > sensitivity ||
		   OuyaSDK.OuyaInput.GetAxisRaw(3, OuyaAxis) > sensitivity)
			isAxisMoved = true;
		#endif

		return isAxisMoved;
	}
/**
	private IEnumerator Wait(float seconds)
	{
		yield return new WaitForSeconds (seconds);
		isInputBlocked = false;
	}
**/
	public void setTextButtonPressed()
	{
		testString = "Play Button Was Pressed";
	}
/**
	public void OnGUI ()
	{
		if (Debug.isDebugBuild)
		{
			//aButton = EventSystem.current.currentSelectedGameObject.gameObject;
			GUILayout.Label ("<size=30><color=white>Player 1</color></size>");
			GUILayout.Label ("<size=30><color=white> EventSystem Name = " + EventSystem.current.name + "</color></size>");
			GUILayout.Label ("<size=30><color=white> Current Selected Game Object Name = " + EventSystem.current.currentSelectedGameObject.name + "</color></size>");
			GUILayout.Label ("<size=30><color=white> Select On Up = " + EventSystem.current.currentSelectedGameObject.GetComponent<Button>().FindSelectableOnUp().name + "</color></size>");
			GUILayout.Label ("<size=30><color=white>" + testString + "</color></size>");
//			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().FindSelectableOnUp().Select();
			//GUILayout.Label ("<size=30><color=white> Select On Up = " + EventSystem.current.currentSelectedGameObject + "</color></size>");
			//EventSystem.current.currentSelectedGameObject.GetComponent(UI.Selectable).navigation.selectOnUp.name;
			//EventSystem.current.currentSelectedGameObject<Button>.name;
		}
	}
**/
}