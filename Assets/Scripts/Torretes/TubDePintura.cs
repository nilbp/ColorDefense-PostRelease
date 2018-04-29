using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubDePintura : MonoBehaviour {

    [Header("Atributes")]

	private int tubRange = 8;

    public float life = 5;

	public float range = 1.2f;
	private float FireRatio = 0.4f; //1 max!!
	public float FireCountdown = 0f;

	[Header("Unity Setup Fields")]

	public HexInfo actualHex;

	public Transform target;
	public string enemyTag = "Enemy";

	public char tubColor;

	public GameObject bulletPrefab;
	public Transform firePoint;

    //ANIMATION VARIABLES
    Animator anim;
    int shootAnimation = Animator.StringToHash("Shoot");

    //per saber el rango cap a endavant en funció el numero de hexes 
    private HexInfo[] ListOfHexesInRange;

    void Start(){

		SetRange ();
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
        anim = GetComponent<Animator>();

        GetComponentInChildren<SkinnedMeshRenderer>().material.color = SetColor(tubColor);
    }
   
    Color SetColor(char tubColor)
    {
        switch (tubColor)
        {
            case 'C': return Color.cyan;
            case 'M': return Color.magenta;
            case 'Y': return Color.yellow;
        }
        return Color.white;
    }

    void SetRange(){

		ListOfHexesInRange = new HexInfo[tubRange];
		HexInfo newHex = actualHex;

		for (int i = 0; i < tubRange; i++) {

			if (newHex.neigbours [0] == null)
				return;

			ListOfHexesInRange[i] = newHex.neigbours [0];
			newHex = newHex.neigbours [0];

		}
	}

	bool IsInHexRange(ColorComponents colorComponents){

		for(int i = 0; i< tubRange; i++){
			if (ListOfHexesInRange [i] == colorComponents.actualHex) 
				return true;	
		}
		return false;
	}

	void Update(){

        if (life <= 0)
        {
            Destroy(gameObject);
            return;
        }

		if (FireCountdown <= 0f && target!=null) 
		{
			Shoot ();
			FireCountdown = 1f / FireRatio;
		}

		FireCountdown -= Time.deltaTime;

	}

    void UpdateTarget()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        ColorComponents minion;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                if (enemy.gameObject != null)
                {
                    minion = enemy.GetComponentInParent<ColorComponents>();

                    if (IsTheMinionShootable(minion))
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                   else
                        nearestEnemy = null; 
                }
            }
        }
        if (nearestEnemy == null)
            target = null;
        else
            target = nearestEnemy.transform;

    }

    public bool IsTheMinionShootable(ColorComponents minion)
    {
        if (!IsInHexRange(minion))
            return false;

        switch (tubColor)
        {
            case 'C':
                if (minion.cyanComponent > 0)              
                    return true;
                break;
            case 'M':
                if (minion.magentaComponent > 0)
                    return true;
                break;
            case 'Y':
                if (minion.yellowComponent > 0)
                    return true;
                break;
        }
        return false;
    }

void Shoot(){

        FindObjectOfType<AudioManager>().Play("Tub4");
        anim.SetTrigger(shootAnimation);

        GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) {

			bullet.chase (target);
            bullet.color = tubColor;

        }
	}
}


