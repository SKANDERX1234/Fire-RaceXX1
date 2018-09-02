using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public GameObject gameover;
    public GameObject replay;

    public static bool Setactive { get; internal set; }

    // Use this for initialization
    void Start () {
        gameover.SetActive(false);
        replay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
            replay.SetActive(true);

            Debug.Log("Game Over");
            
        }
    }
}
