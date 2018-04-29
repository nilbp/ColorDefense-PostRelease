using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ExitBtn(){

		Application.Quit();

	}
	public void OptionsBtn(string options){

		SceneManager.LoadScene (options);

	}

    public void creditos(string creditos)
    {

        SceneManager.LoadScene(creditos);

    }

    public void lvlSelectBtn(string lvlSelector){

        Time.timeScale = 1;
        SceneManager.LoadScene (lvlSelector);
    }
	public void tutorial(string tutorial){

		SceneManager.LoadScene (tutorial);
		FindObjectOfType<AudioManager>().Stop("Tema1");
		FindObjectOfType<AudioManager>().Play("Tema2");
	}
	public void lvl1(string lvl1){

		SceneManager.LoadScene (lvl1);
		FindObjectOfType<AudioManager>().Stop("Tema1");
		FindObjectOfType<AudioManager>().Play("Tema2");
	}
	public void lvl2(string lvl2){

		SceneManager.LoadScene (lvl2);
		FindObjectOfType<AudioManager>().Stop("Tema1");
		FindObjectOfType<AudioManager>().Play("Tema2");
	}
    public void lvl3(string lvl3)
    {

        SceneManager.LoadScene(lvl3);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void lvl4(string lvl4)
    {

        SceneManager.LoadScene(lvl4);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void lvl5(string lvl5)
    {

        SceneManager.LoadScene(lvl5);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void Lvl6(string lvl6)
    {

        SceneManager.LoadScene(lvl6);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void Lvl7(string lvl7)
    {

        SceneManager.LoadScene(lvl7);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void Lvl8(string lvl8)
    {

        SceneManager.LoadScene(lvl8);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void lvl9(string lvl9)
    {

        SceneManager.LoadScene(lvl9);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Tema2");
    }

    public void lvl10(string lvl10)
    {

        SceneManager.LoadScene(lvl10);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
        FindObjectOfType<AudioManager>().Play("BoscMusic");

    }

    public void lvl11(string lvl11)
    {

        SceneManager.LoadScene(lvl11);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
        FindObjectOfType<AudioManager>().Play("BoscMusic");

    }

    public void lvl12(string lvl12)
    {

        SceneManager.LoadScene(lvl12);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
        FindObjectOfType<AudioManager>().Play("BoscMusic");

    }

    public void lvl13(string lvl13)
    {

        SceneManager.LoadScene(lvl13);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl14(string lvl14)
    {

        SceneManager.LoadScene(lvl14);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl15(string lvl15)
    {

        SceneManager.LoadScene(lvl15);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl16(string lvl16)
    {

        SceneManager.LoadScene(lvl16);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl17(string lvl17)
    {

        SceneManager.LoadScene(lvl17);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl18(string lvl18)
    {

        SceneManager.LoadScene(lvl18);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl19(string lvl19)
    {

        SceneManager.LoadScene(lvl19);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("Bosc");
    }

    public void lvl20(string lvl20)
    {

        SceneManager.LoadScene(lvl20);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Stop("Bosc");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl21(string lvl21)
    {

        SceneManager.LoadScene(lvl21);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl22(string lvl22)
    {

        SceneManager.LoadScene(lvl22);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl23(string lvl23)
    {

        SceneManager.LoadScene(lvl23);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl24(string lvl24)
    {

        SceneManager.LoadScene(lvl24);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl25(string lvl25)
    {

        SceneManager.LoadScene(lvl25);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl26(string lvl26)
    {

        SceneManager.LoadScene(lvl26);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl27(string lvl27)
    {

        SceneManager.LoadScene(lvl27);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl28(string lvl28)
    {

        SceneManager.LoadScene(lvl28);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void lvl29(string lvl29)
    {

        SceneManager.LoadScene(lvl29);
        FindObjectOfType<AudioManager>().Stop("Tema1");
        FindObjectOfType<AudioManager>().Play("VentArtic");
    }

    public void mainMenu(string MainMenu){

        Time.timeScale = 1;
		SceneManager.LoadScene (MainMenu);
        FindObjectOfType<AudioManager>().Stop("Tema2");
        FindObjectOfType<AudioManager>().Stop("Bosc");
        FindObjectOfType<AudioManager>().Stop("BoscMusic");
        FindObjectOfType<AudioManager>().Stop("ArticMusic");
        FindObjectOfType<AudioManager>().Stop("VentArtic");
        FindObjectOfType<AudioManager>().Play("Tema1");
	}

    public void SelectorBosc(string SelectorBosc)
    {
        SceneManager.LoadScene(SelectorBosc);
    }

    public void SelectorIce(string SelectorIce)
    {
        SceneManager.LoadScene(SelectorIce);
    }

    public void SelectorSabana(string SelectorSabana)
    {
        SceneManager.LoadScene(SelectorSabana);
    }

    //Funció d desbloquejar nivells
    public void EndLevel(int level)
    {
        int currentLevelProgress = PlayerPrefs.GetInt("levelReached");

        if (level < currentLevelProgress) { return; }

        else { PlayerPrefs.SetInt("levelReached", level); }
    }
}
