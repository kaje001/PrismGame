using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour {

	public void ToggleSelf(){
		if (gameObject.activeSelf) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
		}
	}
}
