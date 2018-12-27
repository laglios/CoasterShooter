using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<Collider>().enabled = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
