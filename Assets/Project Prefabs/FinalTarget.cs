using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalTarget : Damageable {

	
	// Update is called once per frame
	void Update () {
		
	}

    public new void damage()
    {
        health--;
        if (health < 1)
        {
            World.GetComponent<WorldDebug>().score += Point*2;
            this.gameObject.SetActive(false);
            SceneManager.LoadScene("MainScene");
        }
    }
}
