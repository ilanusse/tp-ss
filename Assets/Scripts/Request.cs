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
	private float baseVelocity;
	public int tupleId;
	public bool prefab;
	public float lossProbability;
	public List<Node> visited = new List<Node> ();
	public Material foundColor;

	public Statistics stats;
	private float timeElapsed;

	void Start () {
		foundInfo = false;
		baseVelocity = velocity;
		resetVelocity ();
		timeElapsed = 0;
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
		stats.addDelivered (this);
		Destroy (gameObject);
	}

	void requestLost() {
		stats.addDropped ();
		Destroy (gameObject);
	}

	void resetVelocity() {
		velocity = GaussGenerator.getNormal (velocity, velocity / 10);
		step = velocity * Time.fixedDeltaTime;
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
		timeElapsed += Time.fixedDeltaTime * 75;																																												timeElapsed += Time.fixedDeltaTime * 75;
	}

	public float getTimeElapsed() {
		return timeElapsed;
	}

	void checkIfInfoFound() {
		timeElapsed += target.checkInfoTime ();
		if (target.hasTuple(tupleId)) {
			foundInfo = true;
			renderer.material = foundColor;
		} else {
			visited.Add(target);
			target = target.getNewTarget(visited);
		}
		resetVelocity ();
	}
}
