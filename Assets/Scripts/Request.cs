using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Request : MonoBehaviour {

	public City source;
	public Node target;
	public bool foundInfo;
	public float velocity;
	private float step;
	public int tupleId;
	public bool prefab;
	public float lossProbability;
	public List<Node> visited = new List<Node> ();
	public Material foundColor;

	void Start () {
		foundInfo = false;
		step = velocity * Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!prefab) {
			if (foundInfo) {
				deliverInfo ();
			} else {
				findInfo ();
			}
		}
	}

	void deliverInfo() {
		if (Vector3.Distance (transform.position, source.transform.position) <= 0.1) {
			if (UnityEngine.Random.value <= lossProbability) {
				requestLost();
			}
			deliver ();
		} else {
			transform.position = Vector3.MoveTowards (transform.position, source.transform.position, step);
		}
	}

	void deliver() {
		Debug.Log("DELIVERED :)");
		Destroy (gameObject);
	}

	void requestLost() {
		Debug.Log("REQUEST LOST :(");
		Destroy (gameObject);
	}


	void findInfo() {
		if (Vector3.Distance (transform.position, target.gameObject.transform.position) <= 0.1) {
			if (UnityEngine.Random.value <= lossProbability) {
				requestLost();
			}
			checkIfInfoFound();
		} else {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		}
	}

	void checkIfInfoFound() {
		if (target.hasTuple(tupleId)) {
			foundInfo = true;
			renderer.material = foundColor;
		} else {
			visited.Add(target);
			target = target.getNewTarget(visited);
		}
	}
}
