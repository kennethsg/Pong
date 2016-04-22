using UnityEngine;
using System.Collections;
#if UNITY_ANDROID && !UNITY_EDITOR
using tv.ouya.console.api;
#endif

public class Credits : MonoBehaviour 
{
	OuyaControllerMenuNavigation ouya;

	// Use this for initialization
	void Start () 
	{
		ouya = GetComponent<OuyaControllerMenuNavigation>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if(ouya.GetButtonDown(OuyaController.BUTTON_O) || ouya.GetButtonDown(OuyaController.BUTTON_A))
		{
			OuyaSDK.OuyaInput.ClearButtonStates();
			OuyaSDK.OuyaInput.ClearButtons();
			OuyaSDK.OuyaInput.ClearAxes();
			Application.LoadLevel ("MainMenu");
		}
		#endif
	}
	
}

