using UnityEngine;
using System.Collections;
#if UNITY_ANDROID && !UNITY_EDITOR
using tv.ouya.console.api;
#endif

public class ButtonAction : MonoBehaviour 
{
	public void ChangeToScene(int sceneToChangeTo)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		OuyaSDK.OuyaInput.ClearButtonStates();
		OuyaSDK.OuyaInput.ClearButtons();
		OuyaSDK.OuyaInput.ClearAxes();
		#endif
		Application.LoadLevel (sceneToChangeTo);
	}

	public void ChangeToScene(string sceneToChangeTo)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		OuyaSDK.OuyaInput.ClearButtonStates();
		OuyaSDK.OuyaInput.ClearButtons();
		OuyaSDK.OuyaInput.ClearAxes();
		#endif
		Application.LoadLevel (sceneToChangeTo);
	}
}
