using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadFollow : MonoBehaviour
{
    public GameObject body;
    public GameObject planet;

    public float smooth;

    //private PlayerMouvement vectordirection;

    void Start()
    {
        //vectordirection = body.GetComponent<PlayerMouvement>();

    }


    void FixedUpdate()
    {

        //Laisser camera 2m au dessus du body
        Vector3 rayon = body.transform.position - planet.transform.position;
        rayon.Normalize();
        this.transform.position = Vector3.Lerp(this.transform.position,body.transform.position + 2 * rayon,smooth);

        Debug.DrawRay(this.transform.position, rayon, Color.white); //Tracé rayon

        //CameraRig follow rayon

        transform.rotation = Quaternion.FromToRotation(transform.up, rayon) * transform.rotation;
       
        //-----------make forward align with speedDirection-----------------------------
       //too dizzy

        //Quaternion rotation = Quaternion.LookRotation(vectordirection.speedDirection, transform.up);
        //transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * smooth/100);
    }
    //Camera follow forwward direction : useless
    //transform.rotation = Quaternion.FromToRotation(transform.forward, -Vector3.Cross(rayon, transform.right)) * transform.rotation;


}

