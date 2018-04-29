using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MinionSpawn : MonoBehaviour
{

    const int START_TIME = 11;

    GameObject spawn1;

    public static bool lastMinionDead ;

    public static  int waveSecondsCounter;

    private int counter;

    private bool MobileBuild = false;
    const int incrementPerMobilBuild = 4;

    TutorialManager tutoInstance;

    public static MinionSpawn instance;
    private ColorHUD colorHudInstance;

    //MINION PREFABS
    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;

    private int firstSpawnPoint;
    private int lastSpawnPoint;

    //VARIABLES PEL CANVI DE COLOR
    public int cyanQuantity;
    public int magentaQuantity;
    public int yellowQuantity;

    [System.Serializable]
    public enum ColorComplexity { basic, medium, advanced, random };

    [System.Serializable]
    public enum Behaviour { move_Forward, mov_S, move_Random };

    //STRUCTS PEL LEVEL DESIGN 
    [System.Serializable]
    public class Minion
    {
        public int size;

        //0.2 ÉS VELOCITAT RAONABLE
        public float speed;

        //1 = 1 color. 2 = 2 colors, 3 = 3 colors, 4 = random 
        public ColorComplexity colorComplexity;

        //1 = move forward, 2 = move S, 3 = move random, 4 = random
        public Behaviour behaviour;

        public int cyanQuantity;
        public int magentaQuantity;
        public int yellowQuantity;
    }

    [System.Serializable]
    public struct Waves
    {
        public float spawnRatio;
        public float startTime;
        public Minion[] minion;

    }

    //VARIABLES PER EL LEVEL DESIGN
    [Header("LEVEL DESIGN TOOL")]
    public Waves[] waves;


    void Start()
    {
        instance = this;
        colorHudInstance = ColorHUD.instance;

        StartCoroutine(SpawnManager1());
        firstSpawnPoint = 0;
        lastSpawnPoint = Map.height;
        tutoInstance = GetComponent<TutorialManager>();
      

        tutoInstance.numWaves = waves.Length; //per que el tutorial manager sapiga el numero de waves que hi ha

        lastMinionDead = true;
    }

    IEnumerator SpawnManager1()
    {


        for (int i = 0; i < waves.Length; i++)
        {
            //Time.timeScale = 1;

            waves[i].startTime = START_TIME; // start time constant a totes les waves 11 secs

            while (lastMinionDead == false) { yield return new WaitForSeconds(1f); }

            waveSecondsCounter = (int)waves[i].startTime;

            colorHudInstance.ActiveCounter(true);

            while (waveSecondsCounter > 0)
            {
                waveSecondsCounter--;
                colorHudInstance.UpdateCounter(waveSecondsCounter + " S");

                yield return new WaitForSeconds(1f);
            }

            colorHudInstance.ActiveCounter(false);
            lastMinionDead = false;

            //WaveCountDown(i);

            for (int j = 0; j < waves[i].minion.Length; j++)
            {
                yield return new WaitForSeconds(waves[i].spawnRatio);

                if (j + 1 == waves[i].minion.Length)
                {
                    switch (waves[i].minion[j].behaviour)
                    {
                        case (Behaviour)0:
                            SpawnMinionBehaviour1(waves[i].minion[j], true);
                            break;
                        case (Behaviour)1:
                            SpawnMinionBehaviour2(waves[i].minion[j], true);
                            break;
                        case (Behaviour)2:
                            SpawnMinionBehaviour3(waves[i].minion[j], true);
                            break;
                        default:
                            SpawnMinionBehaviour1(waves[i].minion[j], true);
                            break;
                    }
                }
                else
                {
                    switch (waves[i].minion[j].behaviour)
                    {

                        case (Behaviour)0:
                            SpawnMinionBehaviour1(waves[i].minion[j], false);
                            break;
                        case (Behaviour)1:
                            SpawnMinionBehaviour2(waves[i].minion[j], false);
                            break;
                        case (Behaviour)2:
                            SpawnMinionBehaviour3(waves[i].minion[j], false);
                            break;
                        default:
                            SpawnMinionBehaviour1(waves[i].minion[j], false);
                            break;
                    }
                }
            }
        }
    }

    /*void LoadTutoImages(int i)
    {
        switch (i)
        {
            case 1: tutoInstance.LoadNext();
                break;
            case 2: tutoInstance.LoadFirst(4);
                break;
            case 3: tutoInstance.LoadFirst(5);
                break;
            case 4: tutoInstance.LoadFirst(7);
                break;
        }
    }*/

    int RandomInt(int from, int to)
    {
        return Random.Range(from, to);
    }

    void BuildMinion(Minion minion)
    {

        int acum;
        int counter;
        int aux;



        switch (minion.colorComplexity)
        {
            case ColorComplexity.basic:
                acum = RandomInt(1, 4);
                if (acum == 1)
                    cyanQuantity = minion.size;
                else if (acum == 2)
                    magentaQuantity = minion.size;
                else
                    yellowQuantity = minion.size;
                break;
            case ColorComplexity.medium:
                counter = RandomInt(1, minion.size);
                acum = RandomInt(1, 4);
                if (acum == 1)
                {
                    cyanQuantity = counter;
                    magentaQuantity = minion.size - counter;
                }
                else if (acum == 2)
                {
                    yellowQuantity = counter;
                    cyanQuantity = minion.size - counter;
                }
                else
                {
                    magentaQuantity = counter;
                    yellowQuantity = minion.size - counter;
                }
                break;
            case ColorComplexity.advanced:
                counter = RandomInt(1, minion.size - 1);
                aux = RandomInt(1, minion.size - counter);

                acum = RandomInt(1, 4);
                if (acum == 1)
                {
                    cyanQuantity = counter;
                    magentaQuantity = aux;
                    yellowQuantity = minion.size - (aux + counter);
                }
                else if (acum == 2)
                {
                    yellowQuantity = counter;
                    cyanQuantity = aux;
                    magentaQuantity = minion.size - (aux + counter);
                }
                else
                {
                    magentaQuantity = counter;
                    yellowQuantity = aux;
                    cyanQuantity = minion.size - (aux + counter);
                }
                break;
            case (ColorComplexity)3:
                minion.colorComplexity = (ColorComplexity)RandomInt(1, 3);
                BuildMinion(minion);
                break;
        }
    }

    //FORWARD MOVE
    void SpawnMinionBehaviour1(Minion minion, bool isLastMinion)
    {


        spawn1 = GameObject.Find("Hex_0_" + RandomInt(firstSpawnPoint, lastSpawnPoint));

        //PASSO, A L'SCRIPT DEL MINION, "HEXINFO" (NECESSARI PER QUE EL MINION SAPIGA SABER ON ÉS) I VARIABLES DE COLOR, TAMANY I VELOCITAT (PER QUE SAPIGA COM CONSTRUIR-SE)
        HexInfo spawn1Hex = spawn1.GetComponentInChildren<HexInfo>();
        MinionMovement minionScript = minion1.GetComponent<MinionMovement>();
        ColorComponents colorComponents = minion1.GetComponent<ColorComponents>();

        colorComponents.lastMinionInWave = isLastMinion;
        minionScript.ActualHex = spawn1Hex;

        //BuildMinion(minion);

        //POSA LES VARIABLES DE COLOR EN FUNCIÓ DE "MINION.SIZE" I "MINION.COLORCOMPLEXITY"
        colorComponents.cyanComponent = minion.cyanQuantity;
        colorComponents.magentaComponent = minion.magentaQuantity;
        colorComponents.yellowComponent = minion.yellowQuantity;

        //RESET DE LES VARIABLES GLOBALS DE COLOR
        cyanQuantity = 0;
        magentaQuantity = 0;
        yellowQuantity = 0;

        if (MobileBuild) minionScript.speed = minion.speed * incrementPerMobilBuild;

        else minionScript.speed = minion.speed;

        Instantiate(minion1, spawn1.transform.position, minion1.transform.rotation);
    }

    //S MOVE
    void SpawnMinionBehaviour2(Minion minion, bool isLastMinion)
    {
        //MATEIXA ESTRUCTURA QUE "FORWARD MOVE" PERO INSTANTIAN UN MINION AMB UN ALTRE COMPORTAMENT 
        spawn1 = GameObject.Find("Hex_0_" + RandomInt(firstSpawnPoint + 1, lastSpawnPoint));

        HexInfo spawn1Hex = spawn1.GetComponentInChildren<HexInfo>();
        MinionMovementS minionScript = minion2.GetComponent<MinionMovementS>();
        ColorComponents colorComponents = minion2.GetComponent<ColorComponents>();

        colorComponents.lastMinionInWave = isLastMinion;
        minionScript.ActualHex = spawn1Hex;

        //BuildMinion(minion);
        colorComponents.cyanComponent = minion.cyanQuantity;
        colorComponents.magentaComponent = minion.magentaQuantity;
        colorComponents.yellowComponent = minion.yellowQuantity;

        cyanQuantity = 0;
        magentaQuantity = 0;
        yellowQuantity = 0;

        if (MobileBuild) minionScript.speed = minion.speed * incrementPerMobilBuild;

        else minionScript.speed = minion.speed;

        Instantiate(minion2, spawn1.transform.position, minion2.transform.rotation);

    }

    //RANDOM MOVE
    void SpawnMinionBehaviour3(Minion minion, bool isLastMinion)
    {

        //MATEIXA ESTRUCTURA QUE "FORWARD MOVE" PERO INSTANTIAN UN MINION AMB UN ALTRE COMPORTAMENT 
        spawn1 = GameObject.Find("Hex_0_" + RandomInt(firstSpawnPoint, lastSpawnPoint));

        HexInfo spawn1Hex = spawn1.GetComponentInChildren<HexInfo>();
        MinionMovementRandom minionScript = minion3.GetComponent<MinionMovementRandom>();
        ColorComponents colorComponents = minion3.GetComponent<ColorComponents>();

        colorComponents.lastMinionInWave = isLastMinion;
        minionScript.ActualHex = spawn1Hex;

        //BuildMinion(minion);
        colorComponents.cyanComponent = minion.cyanQuantity;
        colorComponents.magentaComponent = minion.magentaQuantity;
        colorComponents.yellowComponent = minion.yellowQuantity;

        cyanQuantity = 0;
        magentaQuantity = 0;
        yellowQuantity = 0;

        if (MobileBuild) minionScript.speed = minion.speed * incrementPerMobilBuild;

        else minionScript.speed = minion.speed;

        Instantiate(minion3, spawn1.transform.position, minion3.transform.rotation);

    }


}
