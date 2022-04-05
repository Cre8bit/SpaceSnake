using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollowv2 : MonoBehaviour
{
    public GameObject body;
    public GameObject planet;
    public GameObject camerarig;
    public GameObject Cameraeye;
    public float X_smooth;
    public float Z_smooth;
    private Vector3 distance;
    private float X_angle;
    private float Z_angle;

    //private ProcessGravity vectordirection;

    private int numcontact;
    private Vector3 impact;

    public Vector3 direction;
    private Vector3 normale;

    void Start()
    {
        //vectordirection = body.GetComponent<ProcessGravity>();

    }

    void OnCollisionStay(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        impact = contact.point;
        numcontact = collision.contactCount;

    }


    void FixedUpdate()
    {

        //Laisser camera 2m au dessus du body
        distance = body.transform.position - planet.transform.position;
        distance.Normalize();
        this.transform.position = body.transform.position + 2 * distance;

        //reglage angle
        if (numcontact == 0)
        {
            normale = body.transform.position - planet.transform.position;
        }
        else
        {
            normale = body.transform.position - impact;
        }
        normale.Normalize();
        direction = camerarig.transform.forward;
        direction.Normalize();

        direction = direction - Vector3.Dot(direction, normale) * normale;
        direction.Normalize();





        //-------------------DEBUG--------------------------//
        //Debug.Log(X_angle);
        //Debug.DrawRay(this.transform.position, Z_proj, Color.green);
        Debug.DrawRay(this.transform.position, normale, Color.green);
        Debug.DrawRay(this.transform.position, camerarig.transform.up, Color.yellow);
        //Debug.Log(Z_angle);




        //rotation on the x axis & z axis


        Quaternion Z_target = transform.rotation * Quaternion.Euler(0f, 0f, Z_angle);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Z_target, Z_smooth * Time.deltaTime);
        //camerarig.transform.Rotate(0f, 0f, Z_angle, Space.Self);

        X_angle = Vector3.Angle(camerarig.transform.forward, direction);
        Z_angle = Vector3.Angle(camerarig.transform.up, distance);


        transform.rotation = Quaternion.LookRotation(normale);

        transform.rotation = Quaternion.LookRotation(direction);



        if (Mathf.Abs(Z_angle) < 2) { Z_angle = 0; }
        if (Vector3.Dot(camerarig.transform.forward, normale) < 0) { X_angle = 0; }
        if (Vector3.Dot(Cameraeye.transform.up, this.transform.right) < 0) { Z_angle = -Z_angle; }

        Quaternion X_target = transform.rotation * Quaternion.Euler(X_angle, 0f, Z_angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, X_target, X_smooth * Time.deltaTime);



    }
}

