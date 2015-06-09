using UnityEngine;
using System.Collections;

public class Statistics : MonoBehaviour {

	private int droppedRequests;
	private int createdRequests;
	private int deliveredRequests;
	private float totalDeliveryTime;
	// Use this for initialization
	void Start () {
		droppedRequests = 0;
		createdRequests = 0;
		deliveredRequests = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log ("Statistics: ");
		Debug.Log ("Created: " + createdRequests);
		Debug.Log ("Dropped: " + droppedRequests);
		Debug.Log ("Delivered: " + deliveredRequests);
		Debug.Log ("Total Time Elapsed: " + totalDeliveryTime);
		if (deliveredRequests > 0)
			Debug.Log ("Avg. Time Elapsed: " + totalDeliveryTime / deliveredRequests);
	}

	public void addDelivered(Request req) {
		deliveredRequests += 1;
		totalDeliveryTime += req.getTimeElapsed ();
	}

	public void addCreated() {
		createdRequests += 1;
	}

	public void addDropped() {
		droppedRequests += 1;
	}
}
