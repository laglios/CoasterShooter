using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldDebug : MonoBehaviour {

    public bool vr = true;

    public Text txt_score;
    public Text txt_cong;
    public int score = 0;
    public Damageable Final;

	// Use this for initialization
	void Start () {
        if (vr)
        {
            GameObject.Find("Player").transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            GameObject.Find("Player").transform.GetChild(0).gameObject.SetActive(true);
        }
        txt_score.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
        txt_score.text = "Score: " + score;
        if(Final.health == 0)
        {
            StartCoroutine("End");
        }
    }

    IEnumerator End()
    {
        txt_cong.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }

}
