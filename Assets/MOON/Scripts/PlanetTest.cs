using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlanetTest : MonoBehaviour {
	public bool useRadius;
	public float radius;



	public int lodIndex;
	
	
	CelestialBodyGenerator[] bodies;

	void Awake () {
		if (Application.isPlaying) {
			
		
				
			
			

			bodies = FindObjectsOfType<CelestialBodyGenerator> ();

		}
	}

	void Update () {
		if (Application.isPlaying) {
			foreach (var body in bodies) {
				body.SetLOD (0);
			}
		}
	}

	void OnValidate () {
		if (this.gameObject.active)
		{
			var body = GetComponent<CelestialBody>();
			body.radius = radius;
			body.RecalculateMass();

			if (useRadius)
			{
				FindObjectOfType<CelestialBodyGenerator>().transform.localScale = Vector3.one * radius;
			}
			else
			{
				FindObjectOfType<CelestialBodyGenerator>().transform.localScale = Vector3.one;
			}
		}
	}
}