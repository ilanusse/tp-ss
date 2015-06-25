using UnityEngine;
using System.Collections;

public class Plotter : MonoBehaviour {

	public Statistics stats;
	// Use this for initialization
	void Start () {
		PlotManager.Instance.PlotCreate("Avg Time Elapsed", 0, 300, Color.green, new Vector2(1150,400));
	}
	
	// Update is called once per frame
	void Update () {
		PlotManager.Instance.PlotAdd("Avg Time Elapsed", stats.avgTime);
	}
}
