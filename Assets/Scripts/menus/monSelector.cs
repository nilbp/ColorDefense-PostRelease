using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class monSelector : MonoBehaviour {

	//public int level;
	public Button[] levelButtons;
    public Image[] locks;
    private int levelReached;

    public Image levBosc;
    public Image levIce;

    void Start () 
	{       
        levelReached = PlayerPrefs.GetInt ("levelReached");

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i-1 < levelReached)
            {
                if (levelButtons[i] != null)
                {
                    levelButtons[i].interactable = true;
                    locks[i].gameObject.SetActive(false);
                }
            }
		}

        if (levBosc != null && levIce != null)
        {
            if (levelReached >= 10) levBosc.gameObject.SetActive(false);
            if (levelReached >= 20) levIce.gameObject.SetActive(false);              
        }
    }
	
	public void ResetLevelProgress () 
	{
        PlayerPrefs.SetInt("levelReached", 0);
    }
}

  
