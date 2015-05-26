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

	public Node getNewTarget(List<Node> visited) {
		foreach(Node node in neighbourNodes) {
			if (!visited.Contains(node)) {
				return node;
			}
		}
		return this;
	}
}
