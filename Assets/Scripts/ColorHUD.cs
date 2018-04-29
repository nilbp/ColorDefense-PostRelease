using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHUD : MonoBehaviour {

    public GameObject cyanButton;
    public GameObject magentaButton;
    public GameObject yellowButton;

    public static ColorHUD instance;

    public Text waveSecondsText;
    public Button passWave;

    public bool isIce;

    private void Start()
    {
        instance = this;
    }

    public void ActiveCounter(bool a)
    {
        waveSecondsText.gameObject.SetActive(a);
        passWave.gameObject.SetActive(a);
        if (isIce) waveSecondsText.color = Color.black;
    }

    public void UpdateCounter(string a)
    {
        waveSecondsText.text = a;
    }

    public void NoColor()
    {
       MouseManager.ColorInHand = ' ';
        if (cyanButton == null) return;
        cyanButton.SetActive(true);

        if (magentaButton == null) return;
        magentaButton.SetActive(true);

        if (yellowButton == null) return;
        yellowButton.SetActive(true);
    }


    public void CyanButton()
    {
        MouseManager.ColorInHand = 'C';
        cyanButton.SetActive(false);
        magentaButton.SetActive(true);
        yellowButton.SetActive(true);
 
    }
        public void MagentaButton()
	{
        MouseManager.ColorInHand = 'M';
        cyanButton.SetActive(true);
        magentaButton.SetActive(false);
        yellowButton.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Select");
    }
	public void YellowButton()
	{
        MouseManager.ColorInHand = 'Y';
        cyanButton.SetActive(true);
        magentaButton.SetActive(true);
        yellowButton.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Select");
    }
}
