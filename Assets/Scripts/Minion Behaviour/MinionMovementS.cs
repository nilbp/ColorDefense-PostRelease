﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMovementS : MonoBehaviour {

	public HexInfo ActualHex;
	public HexInfo NextHex;

    public Texture iceHexes;
    public Texture DefaultTexture;
    private SkinnedMeshRenderer minionRenderer;
    private ColorComponents ownColor;

	private float Size;

    //QUANTITAT TOTAL DEL MINION
    private Color totalColor;
    public int minionColorQuantity;

    public ParticleSystem particlesDead;
    private Vector3 particlesOffset = new Vector3(0, 0.5f, 0);

    //COMPONTENTS DE COLORS PRIMARIS
    public int cyanQuantity = 0;
    public int magentaQuantity = 0;
    public int yellowQuantity = 0;

    public GameObject cyanIndicator;
    public GameObject magentaIndicator;
    public GameObject yellowIndicator;

    private float cyanIndicatorScale;
    private float magentaIndicatorScale;
    private float yellowIndicatorScale;

    private BuildManager buildManagerInstance;

    //SIZE VARIABLE
    float sizeIncreaseVariable = 0.15f;

    private int counter = 0;

	Transform target;
    private Color lastColor;

    public float speed = 0.2f;

	//EVITA QUE DETECTI COLISIÓ DE COLOR DESPRÉS DE PASSAR PEL HEX
	private float maxDist = 0.7f;
	private float minDist = 0.3f;
	private bool neutralHex = false;

    private TutorialManager tutorialManagerInstance;

    //Valor del mínon en funció de la dificultat de matar-lo
    private int minionValue = 0;

    //AQUESTA FUNCIÓ ES CRIDA DES DE L'SPAWN MANAGER DIENT LA QUANTITAT DE COLOR QUE TE EL MINION EX:(3,4,0) 3 CYANS I 4 MAGENTES

    void ConvineColors(int cyanQuantity, int magentaQuantity, int yellowQuantity)
    {
        if (cyanQuantity < 0) cyanQuantity = 0;
        if (magentaQuantity < 0) magentaQuantity = 0;
        if (yellowQuantity < 0) yellowQuantity = 0;

        ColorIndicatorManager(cyanQuantity, magentaQuantity, yellowQuantity);

        int totalSize = cyanQuantity + magentaQuantity + yellowQuantity;
        Color[] aColors = new Color[totalSize];

        for (int i = 0; i < minionColorQuantity; i++)
        {
            if (cyanQuantity > 0)
            {
                //if (aColors[i] == null) return;
                aColors[i] += Color.cyan;
                cyanQuantity--;
            }
            else if (magentaQuantity > 0)
            {
                //if (aColors[i] == null) return;
                aColors[i] += Color.magenta;
                magentaQuantity--;
            }
            else if (yellowQuantity > 0)
            {

                aColors[i] += Color.yellow;
                yellowQuantity--;
            }
        }

        Color result = new Color(0, 0, 0, 0);
        foreach (Color c in aColors)
        {
            result += c;
        }
        result /= result.maxColorComponent;

        minionColorQuantity = totalSize;

        totalColor = result;

    }

    void ColorIndicatorManager(int cyanQuantity, int magentaQuantity, int yellowQuantity)
    {
        if (cyanQuantity <= 0)
            cyanIndicator.SetActive(false);
        else
            cyanIndicator.SetActive(true);

        if (magentaQuantity <= 0)
            magentaIndicator.SetActive(false);
        else
            magentaIndicator.SetActive(true);

        if (yellowQuantity <= 0)
            yellowIndicator.SetActive(false);
        else
            yellowIndicator.SetActive(true);

        cyanIndicatorScale = (cyanQuantity * 0.02f) + 0.05f;
        magentaIndicatorScale = (magentaQuantity * 0.02f) + 0.05f;
        yellowIndicatorScale = (yellowQuantity * 0.02f) + 0.05f;

        cyanIndicator.transform.localScale = new Vector3(cyanIndicatorScale, cyanIndicatorScale, cyanIndicatorScale);
        magentaIndicator.transform.localScale = new Vector3(magentaIndicatorScale, magentaIndicatorScale, magentaIndicatorScale);
        yellowIndicator.transform.localScale = new Vector3(yellowIndicatorScale, yellowIndicatorScale, yellowIndicatorScale);
    }

    void Start () {

        buildManagerInstance = BuildManager.instance;
        tutorialManagerInstance = TutorialManager.tutorialManager;

        minionRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        ownColor = GetComponent<ColorComponents>();

        //INICIALITZAR ELS PROPIS COLORS
        cyanQuantity = ownColor.cyanComponent;
        magentaQuantity = ownColor.magentaComponent;
        yellowQuantity = ownColor.yellowComponent;

        ConvineColors(cyanQuantity, magentaQuantity, yellowQuantity);
        minionValue = minionColorQuantity * 15;

        NextHex = ActualHex.neigbours[3];
		target = NextHex.gameObject.transform;

		

	}

	void Update(){

        UpdateColorVariables();

        if (minionColorQuantity == 1)
            lastColor = totalColor;

        if (minionColorQuantity <= 0)
        {
			Die ();
        }

        ColorManager();

        if (ActualHex.x == Map.width - 1)
        {
            tutorialManagerInstance.GameOver();
        }

        if (ActualHex.turret != null)
        {
            ActualHex.TurretDealDamage();
            return;
        }

        if (ActualHex.HexColor == 'W' || !neutralHex) {
			MovementS ();
		} 
		else {
			Colision ();
		}

        //FER UPDATE DE LES VARIABLES DE L'SCRIPT "COLOR COMPONENTS"
        cyanQuantity = ownColor.cyanComponent;
        magentaQuantity = ownColor.magentaComponent;
        yellowQuantity = ownColor.yellowComponent;
        ownColor.actualHex = ActualHex;
    }

	void Die()
	{
        FindObjectOfType<AudioManager>().Play("Clinc3");
        MoneyManager.Pigment += minionValue;
		MoneyManager.Combo(transform, minionValue / 15);
		Destroy(gameObject);


		if (ownColor.lastMinionInWave)
		{
			TutorialManager.lastMinion = true;
			return;
		}
		InstantiateParticles();
		return;
	}

    void UpdateColorVariables()
    {
        if (ownColor == null)
            return;

        //FER UPDATE DE LES VARIABLES DE L'SCRIPT "COLOR COMPONENTS"
        cyanQuantity = ownColor.cyanComponent;
        magentaQuantity = ownColor.magentaComponent;
        yellowQuantity = ownColor.yellowComponent;
        ownColor.actualHex = ActualHex;
    }

    void InstantiateParticles()
    {
        Instantiate(particlesDead, transform.position + particlesOffset, particlesDead.transform.rotation);

        MoneyManager.PopUpText(transform, lastColor, minionValue);
    }

    void ColorManager(){

        ConvineColors(cyanQuantity, magentaQuantity, yellowQuantity);

        //CANVIA EL COLOR
        minionRenderer.materials[0].color = totalColor;
        minionRenderer.materials[1].color = totalColor;

        Size = 1 + minionColorQuantity * sizeIncreaseVariable;
        transform.localScale = new Vector3(Size,Size,Size);


	}

	void MovementS(){

		Vector3 dir= target.position - transform.position;
		float distanceThisFrame = speed * Time.fixedDeltaTime;

		//EVITA QUE DETECTI COLISIÓ DE COLOR DESPRÉS DE PASSAR PEL HEX
		if (dir.magnitude < maxDist && dir.magnitude > minDist)
			neutralHex = false;
		else if (dir.magnitude < minDist) {
			neutralHex = true;
			ActualHex = NextHex;
		}

		if (dir.magnitude <= distanceThisFrame)
		{
			if (counter == 0) {
				
				NextHex = ActualHex.neigbours [4];
				transform.Rotate (1, 60, 1);
				counter = 1;
			} 
			else if (counter == 1) 
			{
				
				NextHex = ActualHex.neigbours [3];
				transform.Rotate (1, -60, 1);
				counter = 2;	
			}
			else if(counter == 2)
			{
				NextHex = ActualHex.neigbours [2];
				transform.Rotate (1, -60, 1);
				counter = 3;
			}
			else  
			{
				NextHex = ActualHex.neigbours [3];
				transform.Rotate (1, 60, 1);
				counter = 0;	
			}

			if (NextHex == null) {
				Destroy (gameObject);
				return;
			}

			target = NextHex.gameObject.transform;

		}


		transform.Translate (dir.normalized * distanceThisFrame, Space.World);


	}

	void ResetHexagonColorValues(HexInfo ActualHex){

		ActualHex.HexColor = 'W';
		ActualHex.transform.localScale = new Vector3 (1, 1, 1);
		ActualHex.GetComponent<Renderer>().material.mainTexture = buildManagerInstance.defaultTexture; ;
		ActualHex.ColorDensity = 0;
	}

	void Colision(){

        if (ActualHex.HexColor == 'C')
        {
			if (cyanQuantity > 0) {
				ownColor.cyanComponent--;


			}
            else if (cyanQuantity <= 0)
            {
                ownColor.cyanComponent++;
		

            }
            ResetHexagonColorValues(ActualHex);
        }
        else if (ActualHex.HexColor == 'M')
        {
			if (magentaQuantity > 0) {
				ownColor.magentaComponent--;
			

			}
            else if (magentaQuantity <= 0)
            {
                ownColor.magentaComponent++;
		

            }
            ResetHexagonColorValues(ActualHex);
        }
        else if (ActualHex.HexColor == 'Y')
        {
			if (yellowQuantity > 0) {
				ownColor.yellowComponent--;
			

			}
            else if (yellowQuantity <= 0)
            {
                ownColor.yellowComponent++;
			

            }
            ResetHexagonColorValues(ActualHex);
        }
    }


}



