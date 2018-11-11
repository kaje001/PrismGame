using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrabHex : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	[SerializeField] Controller con;
	[SerializeField] LayerMask layerMask;
	public PlayerBar playerBar;
	public int pos;
	[SerializeField] bool startTile = false;
	bool isPlaced = false;

	// Use this for initialization
	void Start () {
		con = GameObject.FindGameObjectWithTag ("con").GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData data){
		con.activeTile = gameObject;
	}

	public void OnDrag(PointerEventData data){
		Vector3 touchPointInWorld = Camera.main.ScreenToWorldPoint ( new Vector3(data.position.x,data.position.y, 9f));

		transform.position = touchPointInWorld;
	}

	public void OnPointerUp(PointerEventData data){
		//con.activeTile = null;
		RaycastHit hit;
		if(Physics.Raycast(transform.position, Vector3.forward, out hit, 50f, layerMask)){
			//Debug.Log (hit.transform.name);
			if (hit.transform.tag == "board") {
				transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, -0.5f);
				if (!startTile && !isPlaced) {
					playerBar.GetNewTile (pos);
					isPlaced = true;
				}
				transform.parent = hit.transform;
			}
		}

	}
}
