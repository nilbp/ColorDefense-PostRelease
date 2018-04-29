
/*﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour {

	public static GameObject HexSpawn1;
	public static GameObject HexSpawn2;
	public static GameObject HexSpawn3;
	public static GameObject HexSpawn4;

	public GameObject[] minionspawn;
	public GameObject[] minionspawn2;
	public GameObject[] minionspawn3;
	public GameObject[] minionspawn4;

	float move1 = 0f;
	float move2 = 0f;
	float move3 = 0f;
	float move4 = 0f;
	float move5 = 0f;
	float move6 = 0f;
	float move7 = 0f;
	float move8 = 0f;

	private float countDown = 1f;
	private float countDown2 = 4f;
	private float countDown3 = 8f;
	private float countDown4 = 10f;

	public Texture2D DefaultTexture;

	int MinionSpawnSize = 10;
	int MinionStorage = 0;

	HexInfo SpawnHex;
	HexInfo SpawnHex2;
	HexInfo SpawnHex3;
	HexInfo SpawnHex4;

	public float speed = 1;
	private float startTime;
	private float dist;

	float distCover;
	float fracjourn;

	int MinionSpawnCounter=0;
	int MinionSpawnCounter2=0;
	int MinionSpawnCounter3=0;
	int MinionSpawnCounter4=0;

	void Start()
	{
		//yield return new WaitForSeconds (1f);
		//InvokeRepeating ("clicki", spawnTime, spawnTime);

		startTime = Time.time;

		SpawnHex = HexSpawn1.GetComponentInChildren<HexInfo> ();
		SpawnHex2 = HexSpawn2.GetComponentInChildren<HexInfo> ();
		SpawnHex3 = HexSpawn3.GetComponentInChildren<HexInfo> ();
		SpawnHex4 = HexSpawn4.GetComponentInChildren<HexInfo> ();



		dist = Vector3.Distance (minionspawn[0].transform.position, SpawnHex.map.hexLines[SpawnHex.y].columns[SpawnHex.x+1].transform.position);

		distCover = (Time.time - startTime) * speed;
		fracjourn = distCover / dist;

	}
		
	void Update(){

		move1 += Time.deltaTime;
		move2 += Time.deltaTime;
		move3 += Time.deltaTime;
		move4 += Time.deltaTime;
		move5 += Time.deltaTime;
		move6 += Time.deltaTime;
		move7 += Time.deltaTime;
		move8 += Time.deltaTime;

		countDown -= Time.deltaTime;
		countDown2 -= Time.deltaTime;
		countDown3 -= Time.deltaTime;
		countDown4 -= Time.deltaTime;

		SpawnManager ();
	}
	
	void SpawnManager(){

		if (minionspawn [MinionSpawnCounter] != null) {

			if (countDown <= 0) {
				if (MinionSpawnCounter == 3 || MinionSpawnCounter == 5) {

					IAMoveS (SpawnHex, minionspawn, MinionSpawnCounter);
				} 
				else {
					IAMoveForward (SpawnHex, minionspawn, MinionSpawnCounter);
				}
			} 
		}
		if (minionspawn2 [MinionSpawnCounter2] != null) {

			if (countDown2 <= 0) {
				if (MinionSpawnCounter2 == 3 || MinionSpawnCounter2 == 5) {
				
					IAMoveForward2 (SpawnHex2, minionspawn2, MinionSpawnCounter2);

				} else {
				
					IAMoveS2 (SpawnHex2, minionspawn2, MinionSpawnCounter2);

				}
			} 
		}
		if (minionspawn3 [MinionSpawnCounter3] != null) {

			if (countDown3 <= 0) {
				if (MinionSpawnCounter3 == 3 || MinionSpawnCounter3 == 5) {
					IAMoveS3 (SpawnHex3, minionspawn3, MinionSpawnCounter3);

				} else {
					IAMoveForward3 (SpawnHex3, minionspawn3, MinionSpawnCounter3);

				}
			} 
		}
		if (minionspawn4 [MinionSpawnCounter4] != null) {

			if (countDown4 <= 0) {
				if (MinionSpawnCounter4 == 3 || MinionSpawnCounter4 == 5) {
					IAdiagonal (SpawnHex4, minionspawn4, MinionSpawnCounter4);

				} else {
					IADiagonal (SpawnHex4, minionspawn4, MinionSpawnCounter4);

				}
			} 
		}
		else {
			print("LEVEL PASSED!!!");
		}
	}

	void IAMoveForward(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter;


		if (move1>=0.7f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x + 1].transform.position, fracjourn); 
				SpawnHex.x++;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter) {

					ResetSpawn (SpawnHex, 0, 7);

				}
			}
			move1 = 0;
		}
	}

	void IAMoveS(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter;

		if (move2>=0.4f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 0) {

					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y + 1].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;

				} else if (SpawnHex.y % 2 == 1) {

					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y - 1].columns [SpawnHex.x + 1].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x++;

				}
			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter) {
					ResetSpawn (SpawnHex, 0, 7);

				}

			}
			move2 = 0;
		}

	}


	void IAMoveS2(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter2;


		if (move3 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y-1].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y--;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter2) {
					ResetSpawn (SpawnHex, 7, 14);
				}
			}
			move3 = 0;
		}
	}

	void IAMoveForward2(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter2;

		if (move4 > 1f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y - 2].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y-= 2;


			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter2) {
					ResetSpawn (SpawnHex, 7, 14);

				}

			}
			move4 = 0;
		}

	}
	void IAMoveS3(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter3;


		if (move5 > 0.8f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y+1].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y++;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter3) {
					ResetSpawn (SpawnHex, 7, 0);
				}
			}
			move5 = 0;
		}
	}

	void IAMoveForward3(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter3;

		if (move6 > 0.8f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y + 2].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y+= 2;


			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter3) {
					ResetSpawn (SpawnHex, 7, 0);

				}

			}
			move6 = 0;
		}

	}
	void IAdiagonal (HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter4;


		if (move7 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}

			else if (SpawnHex.x<=11) {

				if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x--;
				}

				else if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y--;
				}
			} 	
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;
				}

				else if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y++;
					SpawnHex.x--;
				}
			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter4) {
					ResetSpawn (SpawnHex, 15, 7);
				}
			}
			move7 = 0;
		}
	}
	void IADiagonal (HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter4;


		if (move8 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}

			else if (SpawnHex.x<=12) {

				if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y++;
					SpawnHex.x--;
				}

				else if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;
				}
			} 	
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y--;
				}

				else if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x--;
				}
			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter4) {
					ResetSpawn (SpawnHex, 15, 7);
				}
			}
			move8 = 0;
		}
	}



	void ResetSpawn(HexInfo SpawnHex, int XSpawnPos, int YSpawnPos){
	
		SpawnHex.x = XSpawnPos;
		SpawnHex.y = YSpawnPos;
	}

	//Instantia un Minion en la Position X Y passades com a parametres.
	/*GameObject InstantiateInSpawn(HexInfo SpawnHex, int XSpawnPos, int YSpawnPos, GameObject[] Minion, int i){

		GameObject MinionInstantiat= null;

		if (SpawnHex.x == XSpawnPos && SpawnHex.y == YSpawnPos) {
		
			MinionInstantiat = Instantiate(Minion[i], SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, Quaternion.identity) as GameObject;

		}


		return MinionInstantiat;

	}*/

	/*void densityHigh(HexInfo ActualHex){

		ActualHex.transform.localScale = new Vector3(1, 1, 3 * ActualHex.ColorDensity);
	}

	void SaveHexInArray(GameObject[] Minion, int i, int Size, Color color, string Color){


		for (int a = i; a < Size; a++) {
			if (Minion [a] == null) {

				GameObject MinionChanged = (GameObject)Instantiate (Minion [i], new Vector3 (-4, 0, 2), Quaternion.identity);
				MinionChanged.GetComponent<MeshRenderer> ().material.color = color;
				MinionChanged.name = Color + "Minion";

				Minion [a] = MinionChanged;
				break;

			}
		}
	}
		
	void ResetHexagonColorValues(HexInfo SpawnHex, MeshRenderer HexColor){

		SpawnHex.HexColor = 'W';
		SpawnHex.transform.localScale = new Vector3 (1, 1, 1);
		HexColor.material.mainTexture = null;
		SpawnHex.ColorDensity = 0;
	}

	void ColisionColorDetection(HexInfo SpawnHex, GameObject[] Minion, int i){


		MeshRenderer MinionColor = Minion[i].GetComponent<MeshRenderer> ();
		MeshRenderer HexColor = SpawnHex.GetComponent<MeshRenderer> ();

		if (Minion[i].name == "cyanMinion") {
			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;

			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;

			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;

			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;

			}
		}
		
		else if(Minion[i].name == "magentaMinion"){

			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;

			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;

			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;

			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;

			}
		}

		else if (Minion[i].name == "yellowMinion"){
			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;
			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;
			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;
			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;
			}
		}

		if (Minion [i].name == "blueMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
					
			} else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);


			} else if (SpawnHex.HexColor == 'R') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			}
		} else if (Minion [i].name == "redMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'R') {


				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);
			}
		}

		else if (Minion[i].name == "greenMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

		 	} else if (SpawnHex.HexColor == 'B'){

			ResetHexagonColorValues (SpawnHex, HexColor);
			MinionSpawnCounter++;
			Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'R'){


				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'G'){


				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion[i]);
			}
		}
	/*	if (Minion[i].name == "CyanMinion") {

			if (SpawnHex.HexColor == 'C') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);

			}
			else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);

				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "Blue");



			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "Green");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter2++;

		}

		else if(Minion[i].name == "MagentaMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "Blue");


			} else if (SpawnHex.HexColor == 'M') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "Red");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter2++;


		}

		else if (Minion[i].name == "YellowMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "Green");

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "Red");

			} else if (SpawnHex.HexColor == 'Y') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter2++;

		}
		if (Minion [i].name == "BlueMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				SpawnHex.ColorDensity++;
				MinionSpawnCounter2++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);


			} else if (SpawnHex.HexColor == 'R') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion [i]);

			}
		} else if (Minion [i].name == "RedMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'R') {


				SpawnHex.ColorDensity++;
				MinionSpawnCounter2++;
				densityHigh (SpawnHex);
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion [i]);
			}
		}

		else if (Minion[i].name == "GreenMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B'){

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'R'){


				SpawnHex.ColorDensity++;
				MinionSpawnCounter2++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'G'){


				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter2++;
				Destroy (Minion[i]);
			}
		}
		if (Minion[i].name == "CCyanMinion") {

			if (SpawnHex.HexColor == 'C') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);

			}
			else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);

				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "BBlue");



			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "GGreen");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter3++;

		}

		else if(Minion[i].name == "MMagentaMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "BBlue");


			} else if (SpawnHex.HexColor == 'M') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "RRed");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter3++;


		}

		else if (Minion[i].name == "YYellowMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "GGreen");

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "RRed");

			} else if (SpawnHex.HexColor == 'Y') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter3++;

		}
		if (Minion [i].name == "BBlueMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				SpawnHex.ColorDensity++;
				MinionSpawnCounter3++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);


			} else if (SpawnHex.HexColor == 'R') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion [i]);

			}
		} else if (Minion [i].name == "RRedMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'R') {


				SpawnHex.ColorDensity++;
				MinionSpawnCounter3++;
				densityHigh (SpawnHex);
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion [i]);
			}
		}

		else if (Minion[i].name == "GGreenMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B'){

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'R'){


				SpawnHex.ColorDensity++;
				MinionSpawnCounter3++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'G'){


				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter3++;
				Destroy (Minion[i]);
			}
		}
		if (Minion[i].name == "ccyanMinion") {

			if (SpawnHex.HexColor == 'C') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);

			}
			else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);

				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "bblue");



			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "ggreen");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter4++;

		}

		else if(Minion[i].name == "mmagentaMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "bblue");


			} else if (SpawnHex.HexColor == 'M') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "rred");

			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter4++;


		}

		else if (Minion[i].name == "yyellowMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "ggreen");

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "rred");

			} else if (SpawnHex.HexColor == 'Y') {

				SpawnHex.ColorDensity++;
				densityHigh (SpawnHex);


			} else {

				ResetHexagonColorValues (SpawnHex, HexColor);

			}

			Destroy (Minion[i]);
			MinionSpawnCounter4++;

		}
		if (Minion [i].name == "bblueMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				SpawnHex.ColorDensity++;
				MinionSpawnCounter4++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);


			} else if (SpawnHex.HexColor == 'R') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion [i]);

			}
		} else if (Minion [i].name == "rredMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'R') {


				SpawnHex.ColorDensity++;
				MinionSpawnCounter4++;
				densityHigh (SpawnHex);
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion [i]);
			}
		}

		else if (Minion[i].name == "ggreenMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B'){

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'R'){


				SpawnHex.ColorDensity++;
				MinionSpawnCounter4++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'G'){


				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter4++;
				Destroy (Minion[i]);
			}
		}


	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour {

	public static GameObject HexSpawn1;
	public static GameObject HexSpawn2;
	public static GameObject HexSpawn3;
	public static GameObject HexSpawn4;

	public GameObject[] minionspawn;
	public GameObject[] minionspawn2;
	public GameObject[] minionspawn3;
	public GameObject[] minionspawn4;

	float move1 = 0f;
	float move2 = 0f;
	float move3 = 0f;
	float move4 = 0f;
	float move5 = 0f;
	float move6 = 0f;
	float move7 = 0f;
	float move8 = 0f;

	private float countDown = 1f;
	private float countDown2 = 4f;
	private float countDown3 = 8f;
	private float countDown4 = 10f;

	public Texture2D DefaultTexture;

	int MinionSpawnSize = 10;
	int MinionStorage = 0;

	HexInfo SpawnHex;
	HexInfo SpawnHex2;
	HexInfo SpawnHex3;
	HexInfo SpawnHex4;

	public float speed = 1;
	private float startTime;
	private float dist;

	float distCover;
	float fracjourn;

	int MinionSpawnCounter=0;
	int MinionSpawnCounter2=0;
	int MinionSpawnCounter3=0;
	int MinionSpawnCounter4=0;

	void Start()
	{
		//yield return new WaitForSeconds (1f);
		//InvokeRepeating ("clicki", spawnTime, spawnTime);

		startTime = Time.time;

		SpawnHex = HexSpawn1.GetComponentInChildren<HexInfo> ();
		SpawnHex2 = HexSpawn2.GetComponentInChildren<HexInfo> ();
		SpawnHex3 = HexSpawn3.GetComponentInChildren<HexInfo> ();
		SpawnHex4 = HexSpawn4.GetComponentInChildren<HexInfo> ();



		dist = Vector3.Distance (minionspawn[0].transform.position, SpawnHex.map.hexLines[SpawnHex.y].columns[SpawnHex.x+1].transform.position);

		distCover = (Time.time - startTime) * speed;
		fracjourn = distCover / dist;

	}
		
	void Update(){

		move1 += Time.deltaTime;
		move2 += Time.deltaTime;
		move3 += Time.deltaTime;
		move4 += Time.deltaTime;
		move5 += Time.deltaTime;
		move6 += Time.deltaTime;
		move7 += Time.deltaTime;
		move8 += Time.deltaTime;

		countDown -= Time.deltaTime;
		countDown2 -= Time.deltaTime;
		countDown3 -= Time.deltaTime;
		countDown4 -= Time.deltaTime;

		SpawnManager ();
	}
	
	void SpawnManager(){

		if (minionspawn [MinionSpawnCounter] != null) {

			if (countDown <= 0) {
				if (MinionSpawnCounter == 3 || MinionSpawnCounter == 5) {

					IAMoveS (SpawnHex, minionspawn, MinionSpawnCounter);
				} 
				else {
					IAMoveForward (SpawnHex, minionspawn, MinionSpawnCounter);
				}
			} 
		}
		if (minionspawn2 [MinionSpawnCounter2] != null) {

			if (countDown2 <= 0) {
				if (MinionSpawnCounter2 == 3 || MinionSpawnCounter2 == 5) {
				
					IAMoveForward2 (SpawnHex2, minionspawn2, MinionSpawnCounter2);

				} else {
				
					IAMoveS2 (SpawnHex2, minionspawn2, MinionSpawnCounter2);

				}
			} 
		}
		if (minionspawn3 [MinionSpawnCounter3] != null) {

			if (countDown3 <= 0) {
				if (MinionSpawnCounter3 == 3 || MinionSpawnCounter3 == 5) {
					IAMoveS3 (SpawnHex3, minionspawn3, MinionSpawnCounter3);

				} else {
					IAMoveForward3 (SpawnHex3, minionspawn3, MinionSpawnCounter3);

				}
			} 
		}
		if (minionspawn4 [MinionSpawnCounter4] != null) {

			if (countDown4 <= 0) {
				if (MinionSpawnCounter4 == 3 || MinionSpawnCounter4 == 5) {
					IAdiagonal (SpawnHex4, minionspawn4, MinionSpawnCounter4);

				} else {
					IADiagonal (SpawnHex4, minionspawn4, MinionSpawnCounter4);

				}
			} 
		}
		else {
			print("LEVEL PASSED!!!");
		}
	}

	void IAMoveForward(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter;


		if (move1>=0.7f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x + 1].transform.position, fracjourn); 
				SpawnHex.x++;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter) {

					ResetSpawn (SpawnHex, 0, 7);

				}
			}
			move1 = 0;
		}
	}

	void IAMoveS(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter;

		if (move2>=0.4f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 0) {

					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y + 1].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;

				} else if (SpawnHex.y % 2 == 1) {

					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y - 1].columns [SpawnHex.x + 1].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x++;

				}
			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter) {
					ResetSpawn (SpawnHex, 0, 7);

				}

			}
			move2 = 0;
		}

	}


	void IAMoveS2(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter2;


		if (move3 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y-1].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y--;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter2) {
					ResetSpawn (SpawnHex, 7, 14);
				}
			}
			move3 = 0;
		}
	}

	void IAMoveForward2(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter2;

		if (move4 > 1f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y - 2].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y-= 2;


			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter2) {
					ResetSpawn (SpawnHex, 7, 14);

				}

			}
			move4 = 0;
		}

	}
	void IAMoveS3(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter3;


		if (move5 > 0.8f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}


			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion[i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y+1].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y++;


			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter3) {
					ResetSpawn (SpawnHex, 7, 0);
				}
			}
			move5 = 0;
		}
	}

	void IAMoveForward3(HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter3;

		if (move6 > 0.8f) {

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {


				Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y + 2].columns [SpawnHex.x].transform.position, fracjourn); 
				SpawnHex.y+= 2;


			} 

			else {
				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);	

				if (LocalSpawnCounter != MinionSpawnCounter3) {
					ResetSpawn (SpawnHex, 7, 0);

				}

			}
			move6 = 0;
		}

	}
	void IAdiagonal (HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter4;


		if (move7 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}

			else if (SpawnHex.x<=11) {

				if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x--;
				}

				else if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y--;
				}
			} 	
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;
				}

				else if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y++;
					SpawnHex.x--;
				}
			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter4) {
					ResetSpawn (SpawnHex, 15, 7);
				}
			}
			move7 = 0;
		}
	}
	void IADiagonal (HexInfo SpawnHex, GameObject[] Minion, int i){
		int LocalSpawnCounter= MinionSpawnCounter4;


		if (move8 > 1f) {


			//GameObject MinionInstantiat = InstantiateInSpawn (SpawnHex, 0, 2, Minion, i);

			if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].Nucli == true) {

				SceneManager.LoadScene ("MainMenu");

			}

			else if (SpawnHex.x<=12) {

				if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y++;
					SpawnHex.x--;
				}

				else if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y +1 ].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y++;
				}
			} 	
			else if (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].HexColor == 'W') {

				if (SpawnHex.y % 2 == 1) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x].transform.position, fracjourn); 
					SpawnHex.y--;
				}

				else if (SpawnHex.y % 2 == 0) {
					Minion [i].transform.position = Vector3.Lerp (SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, SpawnHex.map.hexLines [SpawnHex.y -1].columns [SpawnHex.x -1 ].transform.position, fracjourn); 
					SpawnHex.y--;
					SpawnHex.x--;
				}
			} 	

			else {

				ColisionColorDetection (SpawnHex.map.hexLines[SpawnHex.y].columns [SpawnHex.x], Minion, i);

				if (LocalSpawnCounter != MinionSpawnCounter4) {
					ResetSpawn (SpawnHex, 15, 7);
				}
			}
			move8 = 0;
		}
	}



	void ResetSpawn(HexInfo SpawnHex, int XSpawnPos, int YSpawnPos){
	
		SpawnHex.x = XSpawnPos;
		SpawnHex.y = YSpawnPos;
	}

	//Instantia un Minion en la Position X Y passades com a parametres.
	/*GameObject InstantiateInSpawn(HexInfo SpawnHex, int XSpawnPos, int YSpawnPos, GameObject[] Minion, int i){

		GameObject MinionInstantiat= null;

		if (SpawnHex.x == XSpawnPos && SpawnHex.y == YSpawnPos) {
		
			MinionInstantiat = Instantiate(Minion[i], SpawnHex.map.hexLines [SpawnHex.y].columns [SpawnHex.x].transform.position, Quaternion.identity) as GameObject;

		}


		return MinionInstantiat;

	}

	void densityHigh(HexInfo ActualHex){

		ActualHex.transform.localScale = new Vector3(1, 1, 3 * ActualHex.ColorDensity);
	}

	void SaveHexInArray(GameObject[] Minion, int i, int Size, Color color, string Color){


		for (int a = i; a < Size; a++) {
			if (Minion [a] == null) {

				GameObject MinionChanged = (GameObject)Instantiate (Minion [i], new Vector3 (-4, 0, 2), Quaternion.identity);
				MinionChanged.GetComponent<MeshRenderer> ().material.color = color;
				MinionChanged.name = Color + "Minion";

				Minion [a] = MinionChanged;
				break;

			}
		}
	}
		
	void ResetHexagonColorValues(HexInfo SpawnHex, MeshRenderer HexColor){

		SpawnHex.HexColor = 'W';
		SpawnHex.transform.localScale = new Vector3 (1, 1, 1);
		HexColor.material.mainTexture = null;
		SpawnHex.ColorDensity = 0;
	}

	void ColisionColorDetection(HexInfo SpawnHex, GameObject[] Minion, int i){


		MeshRenderer MinionColor = Minion[i].GetComponent<MeshRenderer> ();
		MeshRenderer HexColor = SpawnHex.GetComponent<MeshRenderer> ();

		if (Minion[i].name == "cyanMinion") {
			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;

			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;

			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;

			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);

				}
				else if (SpawnHex.HexColor == 'M') {


					ResetHexagonColorValues (SpawnHex, HexColor);

					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");

				} 
				else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} 
				else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;

			}
		}
		
		else if(Minion[i].name == "magentaMinion"){

			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;

			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;

			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;

			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.blue, "blue");


				} else if (SpawnHex.HexColor == 'M') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else if (SpawnHex.HexColor == 'Y') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;

			}
		}

		else if (Minion[i].name == "yellowMinion"){
			if (Minion[i].tag=="1"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter++;
			}
			else if (Minion[i].tag=="2"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter2++;
			}
			else if (Minion[i].tag=="3"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter3++;
			}
			else if (Minion[i].tag=="4"){
				if (SpawnHex.HexColor == 'C') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.green, "green");

				} else if (SpawnHex.HexColor == 'M') {

					ResetHexagonColorValues (SpawnHex, HexColor);
					SaveHexInArray(Minion, i, MinionSpawnSize, Color.red, "red");

				} else if (SpawnHex.HexColor == 'Y') {

					SpawnHex.ColorDensity++;
					densityHigh (SpawnHex);


				} else {

					ResetHexagonColorValues (SpawnHex, HexColor);

				}

				Destroy (Minion[i]);
				MinionSpawnCounter4++;
			}
		}

		if (Minion [i].name == "blueMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);
					
			} else if (SpawnHex.HexColor == 'M') {


				ResetHexagonColorValues (SpawnHex, HexColor);


			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);


			} else if (SpawnHex.HexColor == 'R') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			}
		} else if (Minion [i].name == "redMinion") {

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'B') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'R') {


				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion [i]);

			} else if (SpawnHex.HexColor == 'G') {

				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion [i]);
			}
		}

		else if (Minion[i].name == "greenMinion"){

			if (SpawnHex.HexColor == 'C') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'M') {

				ResetHexagonColorValues (SpawnHex, HexColor);

			} else if (SpawnHex.HexColor == 'Y') {

				ResetHexagonColorValues (SpawnHex, HexColor);

		 	} else if (SpawnHex.HexColor == 'B'){

			ResetHexagonColorValues (SpawnHex, HexColor);
			MinionSpawnCounter++;
			Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'R'){


				SpawnHex.ColorDensity++;
				MinionSpawnCounter++;
				densityHigh (SpawnHex);
				Destroy (Minion[i]);

			} else if (SpawnHex.HexColor == 'G'){


				ResetHexagonColorValues (SpawnHex, HexColor);
				MinionSpawnCounter++;
				Destroy (Minion[i]);
			}
		}
	}
}*/
