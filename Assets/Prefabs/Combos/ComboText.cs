using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboText : MonoBehaviour {

	void Start () {

        Invoke("Destroy", 1.5f);
	}
	

	void Destroy ()
    {
        Destroy(gameObject);	
	}
}
