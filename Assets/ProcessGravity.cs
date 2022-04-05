using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessGravity : MonoBehaviour
{
    public GameObject planet;

    public float gravity = 9.81f;
    


    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  
    // Update is called once per frame
    void FixedUpdate()
    {
       
        ProcessG();

    }

   
    void ProcessG()
    {
        Vector3 rayon = transform.position - planet.transform.position;
        rb.AddForce(-rayon.normalized * gravity * (rb.mass));

    }

   
}