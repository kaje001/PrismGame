using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public GameObject activeTile;
	[SerializeField] GameObject moveTile;
	[SerializeField] GameObject tileParent;
	[SerializeField] GameObject markerTile;

	[SerializeField] Material[] materials;
	[SerializeField] int[] number;
	List<GameObject> moveTiles = new List<GameObject>();
	List<bool> tileTaken = new List<bool> ();

	int activePlayer = 0;
	[SerializeField] GameObject[] playerBars;
	[SerializeField] GameObject startPanel;

	// Use this for initialization
	void Awake () {
		CreateMoveTiles ();
	}

	void CreateMoveTiles(){
		for (int i = 0; i < materials.Length; i++) {
			for(int j = 0; j < number[i];j++){
				GameObject ob = Instantiate (moveTile, tileParent.transform.position, Quaternion.identity, tileParent.transform);
				ob.transform.GetChild(0).GetComponent<Renderer> ().material = materials [i];
				moveTiles.Add (ob);
				tileTaken.Add (false);
			}
		}
	}

	public GameObject GetRandomTile(){
		GameObject ob = null;
		while (ob == null) {
			int r = Random.Range (0, moveTiles.Count);
			if (!tileTaken [r]) {
				tileTaken [r] = true;
				ob = moveTiles [r];
			}
		}
		return ob;
	}

	// Update is called once per frame
	void Update () {
		if (activeTile != null) {

			markerTile.transform.position = new Vector3 (activeTile.transform.position.x, activeTile.transform.position.y, -0.3f);
		}
	}

	public void RotateActiveTile(){
		if (activeTile != null) {
			activeTile.transform.Rotate (Vector3.back, 60f);
		}
	}

	public void NextTurn(){
		playerBars [activePlayer].SetActive (false);
		activePlayer++;
		if (activePlayer > 2) {
			activePlayer = 0;
		}
		playerBars [activePlayer].SetActive (true);
	}

	public void StartGame(){
		playerBars [1].SetActive (false);
		playerBars [2].SetActive (false);
		startPanel.SetActive (false);
	}
}
