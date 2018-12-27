using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour {

    public int health = 1;
    public int Point = 0;
    public GameObject World;


	// Use this for initialization
	void Start () {
        World = GameObject.Find("World");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void damage()
    {
        health--;
        if (health < 1)
        {
            World.GetComponent<WorldDebug>().score += Point; 
            this.gameObject.SetActive(false);
        }
    }
}
