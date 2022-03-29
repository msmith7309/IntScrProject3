using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotScript : MonoBehaviour
{
    public SecurityCamera camScr;

    public Quaternion startRot;

    public Transform player;

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        startRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(camScr.scanning)
        {
            transform.rotation = startRot;
        }
        else if(!camScr.scanning)
        {
            transform.LookAt(player);
        }
    }
}
