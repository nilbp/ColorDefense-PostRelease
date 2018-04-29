using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private Vector3 offsetBuild;

    TubDePintura tubScript;
    SpraiScript spraiScript;
    public GameObject buildEffect;

    public Texture defaultTexture;

	void Awake(){

		if (instance != null) {

			Debug.Log ("More than 1 build manager in scene");
			return;
		}
		instance = this;

}

	private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn(HexInfo hex)
    {
        if (MoneyManager.Pigment < turretToBuild.cost)
        {
            Debug.Log("not enough money to build");
            return;
        }

        if (hex.HexColor == 'W')
        {
            Debug.Log("Can't buil in a empty hex, it must have a color!! :D");
            return;
        }

        MoneyManager.Pigment -= turretToBuild.cost;

        turretToBuild.IncrementNumberOfTurrets();

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, hex.gameObject.transform.position + offsetBuild, turretToBuild.prefab.transform.rotation);

        GameObject buildParticles = (GameObject)Instantiate(buildEffect, hex.transform.position, buildEffect.transform.rotation);
        

        if (turret.GetComponent<TubDePintura>() != null)
        {
            tubScript = turret.GetComponent<TubDePintura>();
            tubScript.actualHex = hex;
            tubScript.tubColor = hex.HexColor;
            hex.HexColor = 'W';
            FindObjectOfType<AudioManager>().Play("Construcció");
            hex.SetColorTo(defaultTexture);
        }
        else if (turret.GetComponent<SpraiScript>() != null)
        {
            spraiScript = turret.GetComponent<SpraiScript>();
            spraiScript.actualHex = hex;
            spraiScript.spraiColor = hex.HexColor;
            hex.HexColor = 'W';
            FindObjectOfType<AudioManager>().Play("Construcció");
            hex.SetColorTo(defaultTexture);
        }

        //S'HA DE POSAR HEX.TURRET DESPRÉS DE TOT ELS IFS PERQUE S'ELIMINI EL COLOR QUAN PINTES
        hex.turret = turret;
        turretToBuild = null;
    }

    public void SelectTurretToBuild(TurretBlueprint turret, Vector3 offset)
    {
        turretToBuild = turret;
        offsetBuild = offset;     
    }


    Color SetColor(char colorChar)
    {
        switch (colorChar)
        {
            case 'C': return Color.cyan;
            case 'M': return Color.magenta;
            case 'Y': return Color.yellow;
        }
        return Color.white;
    }

}
