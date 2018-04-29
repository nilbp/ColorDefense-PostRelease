using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReleasedLevel : MonoBehaviour {

	public static int releasedLevelStatic=1;
	public int releasedLevel;
	
	public void ButtonNextLevel(){
		if (releasedLevelStatic <= releasedLevel) {
			releasedLevelStatic = releasedLevel;
		}
	}
}
