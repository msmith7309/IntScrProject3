using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public SecurityCamera camScr;

    public bool targetSeen = false;

    public bool shooting = false;

    public bool scriptRunning = false;

    public Rigidbody bullet;

    public Transform emitter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camScr.scanning)
        {
            targetSeen = false;
        }
        else if(!camScr.scanning)
        {
            targetSeen = true;
        }
        if(targetSeen)
        {
            if(!scriptRunning)
            {
                StartCoroutine(StartShooting());
            }
        }
        else if(!targetSeen)
        {
            scriptRunning = false;
            shooting = false;
            return;
        }
    }

    void Fire()
    {
        if(shooting)
        {
            Debug.Log("Bang!");
            Rigidbody copy = Instantiate(bullet, emitter.position, emitter.rotation);
            copy.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
            Destroy(copy.gameObject, 3);

            StartCoroutine(CoolDown());
        }
        
    }

    IEnumerator StartShooting()
    {
        Debug.Log("started shooting");
        scriptRunning = true;
        yield return new WaitForSeconds (1.5f);
        shooting = true;
        Fire();
    }

    IEnumerator CoolDown()
    {
        Debug.Log("Cooldown is running");
        shooting = false;
        yield return new WaitForSeconds(0.1f);
        shooting = true;
    }
}
