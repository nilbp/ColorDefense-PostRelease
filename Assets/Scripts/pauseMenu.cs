using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {

	bool paused = false;
	public GameObject panel;

	void Start () {
		Time.timeScale = 1.0f;
		panel.SetActive(false);
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Time.timeScale);

		if (Input.GetKeyDown (KeyCode.Escape)&& paused==true) {
			Time.timeScale = 1.0f;
			paused = false;
			panel.SetActive(false);
		} 
		else if (Input.GetKeyDown (KeyCode.Escape)&& paused==false){
			//Time.timeScale = 0.0f;
			paused = true;
			panel.SetActive(true);

		}
		}
}
