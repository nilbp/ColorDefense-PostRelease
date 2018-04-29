 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexInfo : MonoBehaviour {


	public int x;
	public int y;

	public bool Nucli;
	public int ColorDensity;
	public bool Clickable;

	public char HexColor;
	public Map map;

	public HexInfo[] neigbours;

    [Header("Optional")]
	public GameObject turret;
    public float turretLife = 5;

	public Color hoverColor;
	private MeshRenderer rend;
	private Color startColor;

    BuildManager buildManager;

	void Start(){

		rend = GetComponentInChildren<MeshRenderer> ();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

    public void SetColorTo(Texture defaultTexture)
    {
        if (turret != null)
        {
            Debug.Log("Can't paint under a turret");
            return;
        }
        rend.material.mainTexture = defaultTexture;
    }

    public void TurretDealDamage()
    {
        if (turretLife <= 0)
            Destroy(turret);

        turretLife -= Time.deltaTime;
    }

	void OnMouseDown(){


        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null) {
		
			Debug.Log ("Can't build");
			return;
		}
        buildManager.BuildTurretOn(this);
	}

	void OnMouseEnter(){

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;
		
		//rend.material.color =  hoverColor;

	
	}

	void OnMouseExit()
    {
		//rend.material.color = startColor;
	}
}



