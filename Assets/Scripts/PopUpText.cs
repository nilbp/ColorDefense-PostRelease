using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour {

    

    private void Start()
    {
        Invoke("PlayText", 1);
    }

    void PlayText()
    {
        Destroy(gameObject);
    }
}
