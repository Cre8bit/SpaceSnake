using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    
	[Header("Drag a target object in here.")]
	public Transform target;
	public GameObject body;
	

	[Header("Choose how aggressively it chases.")]
	public float speedPosition;
	public float speedRotation;

	private PlayerMouvement vectordirection;

	void Start()
	{
		vectordirection = body.GetComponent<PlayerMouvement>();

	}

	void FixedUpdate()
	{
		
			transform.position = Vector3.Lerp(transform.position, target.position, speedPosition * Time.deltaTime);
			//transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, speedRotation * Time.deltaTime);

			Quaternion rotation = Quaternion.LookRotation(vectordirection.speedDirection, transform.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * 0.001f);

	}


}
