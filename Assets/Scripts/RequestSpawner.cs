using UnityEngine;
using System.Collections;

public class RequestSpawner : MonoBehaviour {

	public City[] cities;
	public GameObject prefab;
	public int maxTupleId;
	public Statistics stats;

	private float[] probDistribution;
	private int totalPopulation;

	void Start () {
		probDistribution = new float[cities.Length];
		totalPopulation = 0;
		foreach (City city in cities) {
			totalPopulation += city.population;
		}
		for(int i = 0; i < cities.Length ; i++) {
			probDistribution[i] = cities[i].population / (float)totalPopulation;
			if (i != 0) {
				probDistribution[i] += probDistribution[i - 1];
			}
		}
		InvokeRepeating ("createRequest", 2, 2);
	}

	void createRequest() {
		City city = getRandomCity();
		GameObject requestObj = (GameObject)Instantiate (prefab, city.transform.position, prefab.transform.rotation); 
		Request request = requestObj.GetComponent<Request> ();
		request.target = city.closestNode;
		request.source = city;
		request.tupleId = Random.Range (0, maxTupleId + 1);
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
