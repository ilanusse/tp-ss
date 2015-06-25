using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statistics : MonoBehaviour {

	private int droppedRequests;
	private int createdRequests;
	private int deliveredRequests;
	private float totalDeliveryTime;
	public float avgTime;
	
	public Text droppedText;
	public Text deliveredText;
	public Text avgText;
	public Text currentTime;
	public int SimulationTime;
	public string selectedDistribution;
	public GameObject[] Distributions;

	// Use this for initialization
	private float timeElapsed;
	void Start () {
		droppedRequests = 0;
		createdRequests = 0;
		deliveredRequests = 0;
		foreach(GameObject distr in Distributions){
			if(distr.name.Equals(selectedDistribution))
				distr.SetActive(true);
			else
				distr.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timeElapsed += Time.fixedDeltaTime * 70 / 1000;
		if (deliveredRequests > 0 && ((int)timeElapsed) < SimulationTime) {
						droppedText.text = "Dropped Requests: " + droppedRequests.ToString ();
						deliveredText.text = "Delivered Requests: " + deliveredRequests.ToString ();
						currentTime.text = "Time: " + ((int)timeElapsed).ToString () + " s";
		}
		avgTime = (totalDeliveryTime / deliveredRequests);
		avgText.text = "Avg. Time Elapsed: " + (totalDeliveryTime / deliveredRequests).ToString ("F2") + " ms";
		if (timeElapsed >= SimulationTime) {
			currentTime.text = "Time: " + ((int)timeElapsed).ToString () + " s";
		}

	}

	public float getAverageTime() {
		return avgTime;
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
