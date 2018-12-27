using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        laserLine = GetComponent<LineRenderer>();
        aud = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //laserLine.SetPosition(0, gunEnd.position);
        laserLine.SetPosition(0, gunEnd.position);
        if (Input.GetButtonDown(button) && Time.time > nextFire)
        {
            if (aud)
            {
                aud.Play();
            }
            nextFire = Time.time + firerate; // use of the global time to know if you can shoot again.

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = gunEnd.position;
            RaycastHit hit;
            

            if (Physics.Raycast(rayOrigin,gunEnd.transform.forward,out hit, range))
            {
                laserLine.SetPosition(1, hit.point);

                Damageable health = hit.collider.GetComponent<Damageable>();
                if(health != null)
                {
                    health.damage();
                }
                if(hit.rigidbody != null)
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
