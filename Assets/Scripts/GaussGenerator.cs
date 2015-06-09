using UnityEngine;
using System.Collections;

public class GaussGenerator {


	// Using Box-Muller Transformation to get a normal distribution value
	public static float getNormal(float mean, float stdDev) {
			System.Random rand = new System.Random();
			double u1 = rand.NextDouble();
			double u2 = rand.NextDouble();
			double randStdNormal = System.Math.Sqrt(-2.0 * System.Math.Log(u1)) * System.Math.Sin(2.0 * System.Math.PI * u2);
			return mean + stdDev * ((float)randStdNormal);
	}	
}
