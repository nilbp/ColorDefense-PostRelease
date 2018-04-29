using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticualsColor : MonoBehaviour {

    public GameObject particlesCyan;
    public GameObject particlesMagenta;
    public GameObject particlesYellow;
    private Vector3 particlesOffset = new Vector3(0, 0.5f, 0);

    public void InstantiateParticles(Color color)
    {
        Debug.Log("He entrat");
        if(color == Color.cyan)
            Instantiate(particlesCyan, transform.position + particlesOffset, particlesCyan.transform.rotation);
        else if(color == Color.magenta)
            Instantiate(particlesMagenta, transform.position + particlesOffset, particlesMagenta.transform.rotation);
        else if(color == Color.yellow)
            Instantiate(particlesYellow, transform.position + particlesOffset, particlesYellow.transform.rotation);
    }
}
