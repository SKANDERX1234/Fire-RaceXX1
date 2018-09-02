using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memes : MonoBehaviour {
    public GameObject monsterspawner;
    public GameObject monsterspawner2;
    public GameObject monsterspawner3;
	// Use this for initialization
	void Awake () {
        monsterspawner.SetActive(false);
        monsterspawner2.SetActive(false);
        monsterspawner3.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spawnerlimit"){
            monsterspawner.SetActive(true);
            monsterspawner2.SetActive(true);
            monsterspawner3.SetActive(true);
            Debug.Log("memems");

        }
    }
}
