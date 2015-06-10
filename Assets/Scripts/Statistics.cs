using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statistics : MonoBehaviour {

	private int droppedRequests;
	private int createdRequests;
	private int deliveredRequests;
	private float totalDeliveryTime;
	
	public Text droppedText;
	public Text deliveredText;
	public Text avgText;
	// Use this for initialization
	void Start () {
		droppedRequests = 0;
		createdRequests = 0;
		deliveredRequests = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		droppedText.text = "Dropped Requests: " + droppedRequests.ToString();
		deliveredText.text = "Delivered Requests: " + deliveredRequests.ToString();
		if (deliveredRequests > 0)
			avgText.text = "Avg. Time Elapsed: " + (totalDeliveryTime / deliveredRequests).ToString("F2") + " ms";
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
