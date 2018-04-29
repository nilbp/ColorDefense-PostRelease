using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{

    public static bool gameOver;
    public GameObject gameoverPanel;

    public GameObject endPanel;

    private ColorHUD colorHudInstance;

    public int numWaves;

    public static bool lastMinion;
    public GameObject[] panel;
    public int index = 0;

    public static TutorialManager tutorialManager;

    void Start()
    {
        gameOver = false;
      
        tutorialManager = this;

        colorHudInstance = ColorHUD.instance;
        colorHudInstance.NoColor();

        LoadFirst();
        //Invoke("CheckLastMinion", 1);

    }

    private void Update()
    {
        CheckLastMinion();
    }

    void CheckLastMinion()
    {
        if (lastMinion)
        {
            numWaves--;
            lastMinion = false;
            if (numWaves == 0) { endPanel.SetActive(true); return; }

            MinionSpawn.lastMinionDead = true;
            LoadNext();
        }
        //GameOver();
    }

    public void LoadNext()
    {

        index++;

        if (panel[index] == null) return;

        Time.timeScale = 0;
        panel[index].SetActive(true);

        if (colorHudInstance != null)
            colorHudInstance.NoColor();


        if (panel[index - 1] == null) return;

        else panel[index - 1].SetActive(false);



    }

    public void LoadLast()
    {
        panel[index].SetActive(false);

        Time.timeScale = 1;

    }

    public void LoadFirst()
    {
        if (panel[0] == null) return;

        Time.timeScale = 0;
        panel[0].SetActive(true);

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);

        Invoke("ChangeLevel", 3.5f);
    }

    void ChangeLevel()
    {
        gameoverPanel.SetActive(false);  
        SceneManager.LoadScene("lvlSelector");
        
    }
}
