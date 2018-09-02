using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private Vector2 targetPos;
    public float yincrement;
    public int health = 3;
    private Transform startposition;
    public float speed = 30;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "door"){
            SceneManager.LoadScene(2);}

            if (collision.gameObject.tag=="door2"){
                     SceneManager.LoadScene(3);

            }
        if (collision.gameObject.tag=="door3"){
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.tag=="door4"){
            SceneManager.LoadScene(5);
        }




        }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            health--;

            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            targetPos = new Vector2(transform.position.x, transform.position.y + yincrement );
            if (targetPos.y <= -1.2)
            {

                transform.position = targetPos;
                //Debug.Log("car pos" + targetPos.y);
            }
           
        } 
         
         if (Input.GetKeyDown(KeyCode.DownArrow))
            {
            targetPos = new Vector2(transform.position.x, transform.position.y - yincrement);
            if (targetPos.y >= -5.0)
                {
                
                    transform.position = targetPos;
                //Debug.Log("car pos" + targetPos.y);

                }
                }

        healthbar(health);
    





	}

    public void healthbar (int x)
    {
        Debug.Log("hp ="+ x);

        if (x == 2)
        {
            Destroy(heart1);
            Debug.Log("message heart 1 ");
        }
        else if (x == 1)
        {
            Destroy(heart2);
            Debug.Log("message heart 2");
        }
        else if (x == 0)
        {
            Debug.Log("message death");
            Destroy(gameObject);
            Destroy(heart3);// transform.position = targetPos;
        }
    }








}


