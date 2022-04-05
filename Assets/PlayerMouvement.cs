using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    
    public GameObject planet;
    public GameObject cameraRig;
    //public GameObject head;

    //FPS
    public GameObject canvas;

    private Vector3 speedDirection;
    public float speed;
    private float initSpeed;

    //varianle collision
    private Vector3 normal;
    private int numcontact;
    Rigidbody rb;

    void Awake()
    {
        speedDirection = cameraRig.transform.forward;
        initSpeed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        normal = contact.normal;
        Debug.DrawRay(contact.point, normal, Color.red); // tracé de la normale
        numcontact = collision.contactCount;

    }

    void OnCollisionExit(Collision other)
    {
        numcontact = other.contactCount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //détermination de la normale

        if (numcontact ==0 )
        {
            normal = transform.position - planet.transform.position;
            
        }
       

        normal.Normalize();


        ProcessInputs();

        //Projection de speedDirection dans le plan parallèle au sol
        speedDirection = Vector3.ProjectOnPlane(speedDirection, normal);
        speedDirection.Normalize();



        //Give speed
        rb.velocity = speedDirection * speed;

    }

    void ProcessInputs()
    {
        //Trajectoire avec les manettes et rotation tête libre
        Vector2 inp = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if (inp.magnitude != 0)
        {
            //speedDirection = head.transform.right * inp.x - Vector3.Cross(normal, head.transform.right) * inp.y;
            speedDirection = cameraRig.transform.right * inp.x - Vector3.Cross(normal, cameraRig.transform.right) * inp.y;
        }

        //Avancer selon là ou on pointe avec la tête
        //speedDirection = cameraRig.transform.forward;

        //BOOST
        if (OVRInput.Get(OVRInput.Button.One))
        {
            speed = initSpeed * 2;
        }
        else
        {
            speed = initSpeed;
        }

        //Show FPS
        if (OVRInput.Get(OVRInput.Button.Two))
            {
            canvas.SetActive(true);
        }
        else { canvas.SetActive(false); }

    }
}
