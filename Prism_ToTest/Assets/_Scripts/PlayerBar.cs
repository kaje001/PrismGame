using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBar : MonoBehaviour {

	[SerializeField] int player;
	[SerializeField] Transform[] positions;
	GameObject[] tiles;
	[SerializeField] Controller con;

	// Use this for initialization
	void Start () {
		GetNewTile (1);
		GetNewTile (2);
		GetNewTile (3);
	}

	public void GetNewTile(int pos){
		GameObject tile = con.GetRandomTile ();
		GrabHex gh = tile.GetComponent<GrabHex> ();
		gh.pos = pos;
		gh.playerBar = this;
		tile.transform.position = positions [pos - 1].position;
		tile.transform.parent = positions [pos - 1];
	}
}
