using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : GravityObject
{

	public float jumpForce = 20;


	public LayerMask walkableMask;
	public Transform feet;

	Rigidbody rb;

	float yaw;
	float pitch;
	float smoothYaw;
	float smoothPitch;

	float yawSmoothV;
	float pitchSmoothV;

	Vector3 targetVelocity;
	Vector3 cameraLocalPos;
	Vector3 smoothVelocity;
	Vector3 smoothVRef;



	CelestialBody referenceBody;


	
	bool debug_playerFrozen;
	Animator animator;


	/*
	void Update()
	{
		HandleMovement();
	}

	void HandleMovement()
	{
		

		// Movement
		bool isGrounded = IsGrounded();
		Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		
	}

	bool IsGrounded()
	{
		// Sphere must not overlay terrain at origin otherwise no collision will be detected
		// so rayRadius should not be larger than controller's capsule collider radius
		const float rayRadius = .3f;
		const float groundedRayDst = .2f;
		bool grounded = false;

		if (referenceBody)
		{
			var relativeVelocity = rb.velocity - referenceBody.velocity;
			// Don't cast ray down if player is jumping up from surface
			if (relativeVelocity.y <= jumpForce * .5f)
			{
				RaycastHit hit;
				Vector3 offsetToFeet = (feet.position - transform.position);
				Vector3 rayOrigin = rb.position + offsetToFeet + transform.up * rayRadius;
				Vector3 rayDir = -transform.up;

				grounded = Physics.SphereCast(rayOrigin, rayRadius, rayDir, out hit, groundedRayDst, walkableMask);
			}
		}

		return grounded;
	}
	
	void FixedUpdate()
	{
		CelestialBody[] bodies = NBodySimulation.Bodies;
		Vector3 gravityOfNearestBody = Vector3.zero;
		float nearestSurfaceDst = float.MaxValue;

		// Gravity
		foreach (CelestialBody body in bodies)
		{
			float sqrDst = (body.Position - rb.position).sqrMagnitude;
			Vector3 forceDir = (body.Position - rb.position).normalized;
			Vector3 acceleration = forceDir * Universe.gravitationalConstant * body.mass / sqrDst;
			rb.AddForce(acceleration, ForceMode.Acceleration);

			float dstToSurface = Mathf.Sqrt(sqrDst) - body.radius;

			// Find body with strongest gravitational pull 
			if (dstToSurface < nearestSurfaceDst)
			{
				nearestSurfaceDst = dstToSurface;
				gravityOfNearestBody = acceleration;
				referenceBody = body;
			}
		}

		// Rotate to align with gravity up
		Vector3 gravityUp = -gravityOfNearestBody.normalized;
		rb.rotation = Quaternion.FromToRotation(transform.up, gravityUp) * rb.rotation;

		// Move
		rb.MovePosition(rb.position + smoothVelocity * Time.fixedDeltaTime);
	}
	*/
	
}
