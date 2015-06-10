using UnityEngine;

public class Graph : MonoBehaviour {
	
	[Range(10, 100)]
	public int resolution = 10;
	
	private int currentResolution;
	private ParticleSystem.Particle[] points;
	
	private void CreatePoints () {
		currentResolution = resolution;
		points = new ParticleSystem.Particle[resolution];
		float increment = 1f / (resolution - 1);
		for(int i = 0; i < resolution; i++){
			float x = i * increment;
			points[i].position = new Vector3(x, 0f, 0f);
			points[i].color = new Color(x, 0f, 0f);
			points[i].size = 0.1f;
		}
	}
	
	void Update () {
		if (currentResolution != resolution || points == null) {
			CreatePoints();
		}
		for (int i = 0; i < resolution; i++) {
			Vector3 p = points[i].position;
			p.y = p.x;
			points[i].position = p;
			Color c = points[i].color;
			c.g = p.y;
			points[i].color = c;
		}
		particleSystem.SetParticles(points, points.Length);
	}
}