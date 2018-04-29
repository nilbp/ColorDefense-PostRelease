using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret_HUD : MonoBehaviour {

    public TurretBlueprint sprai;
    public TurretBlueprint tub;

    private Vector3 offsetSprai = new Vector3(0, 0.06f, 0);
    private Vector3 offsetTub = new Vector3(0, 0, 0);

    public GameObject panelOpened;
    public GameObject panelClosed;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectSprai()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        buildManager.SelectTurretToBuild(sprai,offsetSprai);
    }

    public void SelectTub()
    {
        FindObjectOfType<AudioManager>().Play("Select");
        buildManager.SelectTurretToBuild(tub,offsetTub);
    }

    public void OpenPanel()
    {
        panelClosed.SetActive(false);
        panelOpened.SetActive(true);
    }
    public void ClosePanel()
    {
        panelClosed.SetActive(true);
        panelOpened.SetActive(false);
    }

}
