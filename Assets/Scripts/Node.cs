using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

	public int minTupleId;
	public int maxTupleId;
	public Node[] neighbourNodes; // SHOULD BE ORDERED IN INCREASING DISTANCE

	public bool hasTuple(int tupleId) {
		return tupleId >= minTupleId && tupleId <= maxTupleId;
	}

	public float checkInfoTime() {
		// APPROX 10 TUPLES PER MS, POSTGRESQL BENCHMARK
		int tupleCount = maxTupleId - minTupleId;
		return GaussGenerator.getNormal (tupleCount / 10, tupleCount / (20 * 10));
	}

	public Node getNewTarget(List<Node> visited) {
		foreach(Node node in neighbourNodes) {
			if (!visited.Contains(node)) {
				return node;
			}
		}
		return this;
	}
}
