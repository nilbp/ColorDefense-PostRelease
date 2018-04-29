using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	//http://catlikecoding.com/unity/tutorials/hex-map/part-1/

	//public HexInfo HexI;

	public GameObject hexprefab1;
    public GameObject hexprefab2;
    public GameObject hexprefab3;
    //public Texture2D SandTexture;
    //size of the map

    //Ha de ser parell (width i heith) SEMPRE!!
    public static int width = 10;
	public static int height = 4;

	private float alfa=90;

	float xOffset = 0.858f;
	float zOffset = 0.750f;


    [System.Serializable]

    public class HexLine
    {
        public HexInfo[] columns;
    }

    public HexLine[] hexLines;

	enum NeighbourPosition
	{
		Left,
		UpLeft,
		UpRight,
		Right,
		DownRight,
		DownLeft,
		NumPositions,
	}

    int RandomInt(int from, int to)
    {
        return Random.Range(from, to);
    }

	void Start () {

        InitializeBoard();
		createMap ();
		FillNeighbours ();
		//ClickableSpace ();

	}

    void InitializeBoard()
    {
        if (gameObject.name == "HexMap(Big)")
        {
            width = 11; height = 6;
        }
    }

	void createMap(){
		
        hexLines = new HexLine[height];
        for (int i = 0; i < height; i ++)
        {
            hexLines[i] = new HexLine();
            hexLines[i].columns = new HexInfo[width];
        }

		for (int x = 0; x < width; x++) {

			for (int y = 0; y < height; y++) {

				float xPos = x * xOffset;

				if (y % 2 == 1) 
				{
					xPos += xOffset/2;
				}

                //Instantiate hex
               
                GameObject Hex_go;

				if (x >= 3)
					Hex_go = (GameObject)Instantiate (hexprefab3, new Vector3 (xPos, 0, y * zOffset), Quaternion.identity);
				else 
					Hex_go = (GameObject)Instantiate (hexprefab1, new Vector3 (xPos, 0, y * zOffset), Quaternion.identity);

                HexInfo hexInfo = Hex_go.GetComponentInChildren<HexInfo> ();
				hexInfo.x = x;
				hexInfo.y = y;
				hexInfo.Nucli = false;
				hexInfo.ColorDensity = 0;
				hexInfo.Clickable = true;
                hexInfo.map = this;
				hexInfo.HexColor = 'W';

					hexLines [y].columns [x] = hexInfo;

					//Rename hexes with coordenate names
					Hex_go.name = "Hex_" + x + "_" + y;

					//Group hexes in a GameObject parent called "Hex"
					Hex_go.transform.SetParent (this.transform);

					Hex_go.isStatic = true;

				if (x < 3)
					hexInfo.Clickable = false;

                if (x > 8)
                    hexInfo.Clickable = false;

			}
		}
	}

	void FillNeighbours(){



		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {


				GameObject Hex_go = GameObject.Find ("Hex_" + x + "_" + y);
				HexInfo ActualHex = Hex_go.GetComponentInChildren<HexInfo> ();
				ActualHex.neigbours	= new HexInfo[6];

				for (int i = (int)NeighbourPosition.Left; i < (int)NeighbourPosition.NumPositions; i++) {
				
				HexInfo neighbour = GetNeighbourByPosition ((NeighbourPosition)i, ActualHex);
				
					if (neighbour != null) {

						ActualHex.neigbours [i] = neighbour;


					}
				}
			}
		}
	}

	void ClickableSpace(){
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {


				GameObject Hex_go = GameObject.Find ("Hex_" + x + "_" + y);
				HexInfo ActualHex = Hex_go.GetComponentInChildren<HexInfo> ();
				MeshRenderer ActualHexRend = ActualHex.GetComponent<MeshRenderer>();

				for (int i = 0; i < 6; i++) {

					if (ActualHex.neigbours [i] != null) {

						if (ActualHex.neigbours [i].Nucli ) {
							ActualHex.Clickable = true;
							ActualHexRend.material.mainTexture = null;
						}

						for(int j=0;j<6;j++){
							
							if (ActualHex.neigbours [i].neigbours [j]!= null) {
								if (ActualHex.neigbours [i].neigbours [j].Nucli) {
									ActualHex.Clickable = true;
									ActualHexRend.material.mainTexture = null;
								}
							} 
						}
					}
				}
			}
		}
	}

	HexInfo GetNeighbourByPosition(NeighbourPosition position, HexInfo ActualHex)
	{
		HexInfo retVal = null;

		switch (position)
		{
		case NeighbourPosition.Left:
			retVal = GetLeftNeighbour (ActualHex);
			break;
		case NeighbourPosition.UpLeft:
			retVal = GetUpLeftNeighbour (ActualHex);
			break;
		case NeighbourPosition.UpRight:
			retVal = GetUpRightNeighbour(ActualHex);
			break;
		case NeighbourPosition.Right:
			retVal = GetRightNeighbour (ActualHex);
			break;
		case NeighbourPosition.DownRight:
			retVal = GetDownRightNeighbour(ActualHex);
			break;
		case NeighbourPosition.DownLeft:
			retVal = GetDownLeftNeighbour (ActualHex);
			break;
		default:
			break;
		}

		return retVal;
	}

	HexInfo GetLeftNeighbour(HexInfo ActualHex)
	{
		HexInfo retVal = null;

		if (ActualHex.x > 0)
		{
			retVal = ActualHex.map.hexLines[ActualHex.y].columns[ActualHex.x-1];
		}

		return retVal;
	}

	HexInfo GetUpLeftNeighbour(HexInfo ActualHex){

		HexInfo retVal = null;

		if (ActualHex.y % 2 == 0 && ActualHex.x > 0 ) {
			retVal = ActualHex.map.hexLines [ActualHex.y+1].columns [ActualHex.x-1];

		} 
		else if (ActualHex.y % 2 == 1 && ActualHex.y < Map.height -1) {
			retVal = ActualHex.map.hexLines [ActualHex.y+1].columns [ActualHex.x];
		}
		return retVal;
	}

	HexInfo GetUpRightNeighbour(HexInfo ActualHex){

		HexInfo retVal = null;

		if (ActualHex.y % 2 == 0) {

			retVal = ActualHex.map.hexLines [ActualHex.y+1].columns [ActualHex.x]; 

		} else if (ActualHex.y % 2 == 1 && ActualHex.x < Map.width - 1 && ActualHex.y < Map.height - 1) {

			retVal = ActualHex.map.hexLines [ActualHex.y + 1].columns [ActualHex.x + 1];
		}
		return retVal;
	}

	HexInfo GetRightNeighbour(HexInfo ActualHex){

		HexInfo retVal = null;

		if (ActualHex.x < Map.width-1) {

			retVal = ActualHex.map.hexLines [ActualHex.y].columns [ActualHex.x+1];

		}

		return retVal;
	}

	HexInfo GetDownRightNeighbour(HexInfo ActualHex){

		HexInfo retVal=null;

		if (ActualHex.y % 2 == 0 && ActualHex.y > 0) {
			retVal = ActualHex.map.hexLines [ActualHex.y-1].columns [ActualHex.x];
		}
		else if (ActualHex.y % 2 == 1 && ActualHex.x < Map.width-1 ) {

			retVal = ActualHex.map.hexLines[ActualHex.y - 1].columns[ActualHex.x + 1];
		}

		return retVal;
	}

	HexInfo GetDownLeftNeighbour(HexInfo ActualHex){

		HexInfo retVal=null;

		if (ActualHex.y % 2 == 0 && ActualHex.x > 0 && ActualHex.y > 0) {
			retVal = ActualHex.map.hexLines [ActualHex.y - 1].columns [ActualHex.x - 1];
		} 
		else if (ActualHex.y % 2 == 1) {
			retVal = ActualHex.map.hexLines [ActualHex.y-1].columns [ActualHex.x];
		}
		return retVal;
	}
}
