using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessGravityv2 : MonoBehaviour
{
    public Transform gravityTarget;

    public float power = 40f;
    public float torque = 40f;
    public float gravity = 9.81f;
    public float speed = 10f;

    public GameObject eye;
    public GameObject planet;

    public Vector3 direction;
    private Vector3 normale;

    private int numcontact;
    private Vector3 impact;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        impact = contact.point;
        numcontact = collision.contactCount;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessVelocity();
        ProcessG();

    }

    void ProcessVelocity()
    {
        if (numcontact == 0)
        {
            normale = this.transform.position - planet.transform.position;
            Debug.Log("vitesse parallèle à vision caméra");
        }
        else
        {
            normale = this.transform.position - impact;

        }
        normale.Normalize();
        Debug.DrawRay(impact, normale, Color.white);

        direction = eye.transform.forward;
        direction.Normalize();

        direction = direction - Vector3.Dot(direction, normale) * normale;
        direction.Normalize();
        Debug.DrawRay(this.transform.position, direction, Color.red);
        rb.velocity = rb.velocity + direction * speed;


    }
    void ProcessG()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));

    }


}