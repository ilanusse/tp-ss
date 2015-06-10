using UnityEngine;
using System.Collections;

public class RequestSpawner : MonoBehaviour {

	public City[] cities;
	public GameObject prefab;
	public int maxTupleId;
	public Statistics stats;
	public float closestNodeProbability;

	private float[] probDistribution;
	private float totalPopulation;

	void Start () {
		probDistribution = new float[cities.Length];
		totalPopulation = 0;
		foreach (City city in cities) {
			totalPopulation += city.population;
		}
		for(int i = 0; i < cities.Length ; i++) {
			probDistribution[i] = cities[i].population / totalPopulation;
			if (i != 0) {
				probDistribution[i] += probDistribution[i - 1];
			}
		}
		InvokeRepeating ("createRequest", 1, 0.2f);
	}

	void createRequest() {
		City city = getRandomCity();
		GameObject requestObj = (GameObject)Instantiate (prefab, city.transform.position, prefab.transform.rotation); 
		Request request = requestObj.GetComponent<Request> ();
		request.target = city.closestNode;
		request.source = city;

		if (Random.Range ((float)0, 1) < closestNodeProbability) {
				request.tupleId = Random.Range (city.closestNode.minTupleId + 1, city.closestNode.maxTupleId + 1);
		} 
		else {
			request.tupleId = Random.Range (0, maxTupleId + 1);
			while(request.tupleId >= city.closestNode.minTupleId && request.tupleId <= city.closestNode.maxTupleId)
				request.tupleId = Random.Range (0, maxTupleId + 1);
		}
//		request.tupleId = Random.Range (0, maxTupleId + 1);
		request.prefab = false;
		stats.addCreated ();
	}

	City getRandomCity() {
		float value = Random.value;
		for(int i = 0; i < cities.Length ; i++) {
			if (value <= probDistribution[i]) {
				return cities[i];
			}
		}
		return cities [0];
	}
}
