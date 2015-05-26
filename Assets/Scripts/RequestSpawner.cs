using UnityEngine;
using System.Collections;

public class RequestSpawner : MonoBehaviour {

	public City[] cities;
	public GameObject prefab;
	public int maxTupleId;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("createRequest", 1, 2);
	}

	void createRequest() {
		City city = cities [Random.Range (0, cities.Length)];
		GameObject requestObj = (GameObject)Instantiate (prefab, city.transform.position, prefab.transform.rotation); 
		Request request = requestObj.GetComponent<Request> ();
		request.target = city.closestNode;
		request.source = city;
		request.tupleId = Random.Range (0, maxTupleId + 1);
		request.prefab = false;
	}
}
