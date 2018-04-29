
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
    private Renderer ownRenderer;
    private ColorComponents targetColors;
    public char color;

	public float speed = 5f;
    public int bulletDamage = 1;

	public GameObject impactEffect;

	public void chase(Transform _target){

		//Aqui dins es pot instanciar particules, set speed of the bulled, damage, etc...
		target = _target;

	}
    private void Start()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        targetColors = target.GetComponent<ColorComponents>();
        ownRenderer = GetComponent<Renderer>();

        switch (color) {

            case 'C': ownRenderer.material.color = Color.cyan;
                break;
            case 'M': ownRenderer.material.color = Color.magenta;
                break;
            case 'Y': ownRenderer.material.color = Color.yellow;
                break;
        }
    }
    private void Update () {

		if (target == null) 
		{

			Destroy (gameObject);
			return;
		
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget(){

		//GameObject effectIns = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		//Destroy (effectIns, 2f); 

		Destroy (gameObject);

        switch (color)
        {
            case 'C':
                targetColors.cyanComponent -= bulletDamage;
                break;
            case 'M':
                targetColors.magentaComponent -= bulletDamage;
                break;
            case 'Y':
                targetColors.yellowComponent -= bulletDamage;
                break;
        }
        

	}
}
