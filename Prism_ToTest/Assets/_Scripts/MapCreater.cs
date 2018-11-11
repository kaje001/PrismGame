using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour {

	[SerializeField] GameObject creater;
	[SerializeField] GameObject tile;

	[SerializeField, Range(0,6)] int circles;
	int currentCircle = 0;

	// Use this for initialization
	void Start () {
		CreateMap ();
	}
	

	void CreateMap(){
		Instantiate (tile, creater.transform.position, creater.transform.rotation, gameObject.transform);
		creater.transform.Translate (Vector3.up);
		for (int i = 0; i < circles; i++) {
			creater.transform.Rotate (Vector3.back, 120f);
			for (int j = 0; j < 6; j++) {
				for (int k = 0; k <= currentCircle; k++) {
					creater.transform.Translate (Vector3.up);
					GameObject ob = Instantiate (tile, creater.transform.position, creater.transform.rotation, gameObject.transform);
					tile.transform.tag = "board";
				}
				creater.transform.Rotate (Vector3.back, 60f);
			}
			creater.transform.Rotate (Vector3.back, -120f);
			creater.transform.Translate (Vector3.up);
			currentCircle++;
		}

	}
}
