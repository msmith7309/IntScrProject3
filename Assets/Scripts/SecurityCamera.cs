using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public Transform player;

    public bool scanning = false;

    Transform emitter;

    public Animator anim;

    public float fieldOfView = 45;
    // Start is called before the first frame update
    void Start()
    {
        emitter = transform.GetChild(0);
        //rend = GetComponent<Renderer>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 rayDirection = (player.position + Vector3.up) - emitter.position;

        float angle = Vector3.Angle(rayDirection, emitter.forward);

        if(angle < fieldOfView)
        {
            if(Physics.Raycast(emitter.position, rayDirection, out hit, 30f))
            {
                if(hit.collider.CompareTag("Player"))
                {
                    scanning = false;
                    Debug.DrawRay(emitter.position, rayDirection, Color.green);
                }
                else
                {
                    scanning = true;
                    Debug.DrawRay(emitter.position, rayDirection, Color.red);
                }
            }
        }
            
        if(scanning)
        {
            anim.SetBool("Scanning", true);
        }
        else if(!scanning)
        {
            anim.SetBool("Scanning", false);
        }

        //Debug.Log("Found an object - distance: " + hit.distance);
    }
}
