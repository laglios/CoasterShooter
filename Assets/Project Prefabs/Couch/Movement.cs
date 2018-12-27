using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public GameObject player;
    public GameObject te;
    public GameObject te2;

    private int state = 0;
	// Use this for initialization
	void Start () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (state == 0) {
            if (other.gameObject.tag == "Player")
            {
                state++;
                te.gameObject.SetActive(false);
                te2.gameObject.SetActive(false);
                player.transform.SetParent(this.transform);
                this.GetComponent<Collider>().enabled = false;
                GetComponent<Animator>().SetBool("Sit", true);
                GetComponent<Animator>().speed =0.25f;
                player.transform.GetChild(0).transform.localRotation = this.transform.rotation;
                player.transform.localPosition = this.transform.position + new Vector3(0f, 700f, -1f);
                player.GetComponent<CharacterController>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (state == 1)
        {
            /*player.transform.localRotation = this.transform.rotation;
            player.transform.GetChild(0).transform.localPosition = this.transform.position + new Vector3(0f, 0f, 1f);
            */
        }

    }
}
