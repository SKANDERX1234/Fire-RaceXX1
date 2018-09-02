using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car1 : MonoBehaviour
{
    public float speed = 30;
    //  public GameObject prefab;
    private Transform startposition;
    Rigidbody2D rb2d;


    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * +speed);

    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "sword")
        {
            Debug.Log("message");
            // Destroy the whole Block
            Destroy(this.gameObject);
        }
        /*Vector3 position = new Vector3(-127.2f, 0, Random.Range(-46.7f, 26.8f));
        Instantiate(gameObject, position, Quaternion.identity);
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.forward * 10);
        */


    }
   
}






