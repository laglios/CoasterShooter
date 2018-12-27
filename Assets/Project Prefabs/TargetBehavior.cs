using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {
    public float movex;
    public float movey;
    public float movez;
    public float rotationx;
    public float rotationy;
    public float rotationz;
    [Space(10)]
    private bool reverse; //false - no change / true - reverse
    public bool backForth = false;
    public float backForthTime;
    [Space(10)]
    public float life;
    private float lifeTimer=0;

    private float timer=0;

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (life != 0)
        {
            lifeTimer += Time.deltaTime;
        }

        if (lifeTimer <= life)
        {

            if (backForth)
            {
                if(timer > backForthTime)
                {
                    reverse = !reverse;
                    timer = timer - backForthTime;
                }

                if (reverse)
                {
                    transform.Rotate(-rotationx, -rotationy, -rotationz);
                    transform.Translate(-movex, -movey, -movez);
                }
                else
                {
                    transform.Rotate(rotationx, rotationy, rotationz);
                    transform.Translate(movex, movey, movez);
                }
            }
            else
            {
                transform.Rotate(rotationx, rotationy, rotationz);
                transform.Translate(movex, movey, movez);

            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
