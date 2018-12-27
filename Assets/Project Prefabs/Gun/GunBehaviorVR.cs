using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GunBehaviorVR : MonoBehaviour
{

    public int gunDamage = 1;
    public float firerate = .25f;
    public float range = 50f;
    public float hitForce = 100f;
    public Transform gunEnd; // where the lazer begin
    public string button;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserLine;
    private float nextFire;

    AudioSource aud;

    public string hand;
    SteamVR_Input_Sources which;

    // Use this for initialization
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        aud = gameObject.GetComponent<AudioSource>();
        if(hand == "Left")
        {
            which = SteamVR_Input_Sources.LeftHand;
        } else if (hand == "Right")
        {
            which = SteamVR_Input_Sources.RightHand;
        } else
        {
            Debug.Log("Main Incomprise");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //laserLine.SetPosition(0, gunEnd.position);
        laserLine.SetPosition(0, gunEnd.position);
        if (SteamVR_Input._default.inActions.GrabPinch.GetStateDown(which) && Time.time > nextFire)
        {
            if (aud)
            {
                aud.Play();
            }
            nextFire = Time.time + firerate; // use of the global time to know if you can shoot again.

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = gunEnd.position;
            RaycastHit hit;


            if (Physics.Raycast(rayOrigin, gunEnd.transform.forward, out hit, range))
            {
                laserLine.SetPosition(1, hit.point);

                Damageable health = hit.collider.GetComponent<Damageable>();
                if (health != null)
                {
                    health.damage();
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (gunEnd.transform.forward * range));
            }

        }
    }

    private IEnumerator ShotEffect()
    {
        //gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
