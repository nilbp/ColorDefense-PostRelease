using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyItSelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destroy", 3);
	}

    private void Destroy()
    {
        Destroy(gameObject);
    }


}
