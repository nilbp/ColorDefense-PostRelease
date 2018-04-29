using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint{

    const int incrementValue = 20;

    public Text costText;

    public GameObject prefab;
    public int cost;
    public int numberOfThisTurrets;

    public void IncrementNumberOfTurrets()
    {
        numberOfThisTurrets++;
        cost += numberOfThisTurrets * incrementValue;

        costText.text = "" + cost;
    }
}
