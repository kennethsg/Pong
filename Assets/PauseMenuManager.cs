using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#if UNITY_ANDROID && !UNITY_EDITOR
using tv.ouya.console.api;
#endif

public class PauseMenuManager : MonoBehaviour
{
	public Canvas pauseCanvas;
	public bool isGamePaused;

	// Use this for initialization
	void Start()
	{
		pauseCanvas.enabled = false;
		isGamePaused = false;
		ResumeGame ();
	}

	public void PauseGame()
	{
		//GameObject.Find("Player01").GetComponent<MonoBehaviour>().enabled = false;
		//GameObject.Find("Player02").GetComponent<MonoBehaviour>().enabled = false;
		//GetComponent<OuyaControllerMenuNavigation>().enabled = true;
		//EventSystem.current.enabled = true;
		//EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().navigation.mode.Explicit;
		pauseCanvas.enabled = true;
		pauseCanvas.gameObject.SetActive (true);
		Time.timeScale = 0;
		isGamePaused = true;
		GetComponent<AudioSource>().Pause();
	}

	public void ResumeGame()
	{
		//GameObject.Find("Player01").GetComponent<MonoBehaviour>().enabled = true;
		//GameObject.Find("Player02").GetComponent<MonoBehaviour>().enabled = true;
		//GetComponent<OuyaControllerMenuNavigation>().enabled = false;
		//EventSystem.current.enabled = false;
		//EventSystem.current.currentSelectedGameObject.GetComponent<Button> ().navigation.mode.None;
		pauseCanvas.enabled = false;
		pauseCanvas.gameObject.SetActive (false);
		Time.timeScale = 1;
		isGamePaused = false;
		GetComponent<AudioSource>().Play();
	}

	public void ChangeGameState()
	{
		if (!isGamePaused)
			PauseGame ();
		else 
			ResumeGame();
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

	// Update is called once per frame
	void Update ()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		//if (OuyaSDK.OuyaInput.GetButtonUp(0, OuyaController.BUTTON_MENU))
		if (GetButtonUp(OuyaController.BUTTON_MENU))
			ChangeGameState();
		#endif
	}
/*
	public void OnGUI ()
	{
		if (Debug.isDebugBuild)
		{

			GUILayout.Label ("<size=30><color=white> MonoBehaviour Player01 = " + GameObject.Find("Player01").GetComponent<MonoBehaviour>().enabled + "</color></size>");
			GUILayout.Label ("<size=30><color=white> MonoBehaviour Player02 = " + GameObject.Find("Player02").GetComponent<MonoBehaviour>().enabled + "</color></size>");
			GUILayout.Label ("<size=30><color=white> Script Name = " + GameObject.Find("Players").GetType() + "</color></size>");

		}
	}
*/
}