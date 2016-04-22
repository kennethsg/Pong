using UnityEngine;
using System.Collections;
using System;

public class MenuManager : MonoBehaviour
{
	public GUISkin skin;

	public KeyCode moveUp;
	public KeyCode moveDown;

	String[] menuOptions = new String[3];

	int selectedIndex = 0;

	void Start() 
	{
		menuOptions[0] = "PLAY";
		menuOptions[1] = "CREDITS";
		menuOptions[2] = "QUIT";
	}

	void Update()
	{
		if (Input.GetKey(moveDown)) 
		{
			incrementSelectedIndex();
		}
		if(Input.GetKey(moveUp))
		{
			decrementSelectedIndex();
		}
	}

	/** Increments the selected index or
	 * set it to 0 in case it's the maximum
	 * index of the array **/ 
	void incrementSelectedIndex()
	{
		if (selectedIndex >= menuOptions.Length-1)
		{
			selectedIndex = 0;
		}
		else
		{
			selectedIndex++;
		}
	}

	/** Decrements the selected index or
	 * set it to the maximum index of 
	 * the aray in case it's 0 **/ 
	void decrementSelectedIndex()
	{
		if (selectedIndex <= 0)
		{
			selectedIndex = menuOptions.Length-1;
		}
		else
		{
			selectedIndex--;
		}
	}

	void OnGUI()
	{
		GUI.skin = this.skin;

		GUI.SetNextControlName (menuOptions[0]);
		if (GUI.Button(new Rect(Screen.width/2-(121/2), 35, 121, 53), menuOptions[0]))
		{

		}
		GUI.SetNextControlName (menuOptions[1]);
		if (GUI.Button(new Rect(Screen.width/2-(121/2), 35+53+20, 121, 53), menuOptions[1]))
		{
			
		}
		GUI.SetNextControlName (menuOptions[2]);
		if (GUI.Button(new Rect(Screen.width/2-(121/2), (35+53+20)+53+20, 121, 53), menuOptions[2]))
		{
			
		}

		GUI.FocusControl (menuOptions[selectedIndex]);
	}
}
