using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

//Just for demonstration, you can replace it with your own code logic.
public class UnitControl : MonoBehaviour
{

    private Animator animator;
    private float walkStartTime = 0;
    private bool isEvade = false;
    public void UnFreeze()
    {
        Time.timeScale = 1;
    }
    Rigidbody2D rb2d;


    void Start()
    {
        animator = this.GetComponent<Animator>();

        //Get a reference to the Rigidbody2D of the Bird
        rb2d = GetComponent<Rigidbody2D>();
        //Go right
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;
        //Freeze time to wait for the player to press Play
        Time.timeScale = 0;
        ReplayButton.SetActive(false);

        //Set the initial velocity of our Bird
        rb2d.velocity = Vector2.right * speed * Time.deltaTime;



    }
    public float speed = 30;


    void FixedUpdate()
    {
        //This is our GetAxisRaw input 
        float h = Input.GetAxisRaw("Horizontal1") * speed;
        float v = Input.GetAxisRaw("Vertical1") * speed;
        //Just calling the Rigidbody2D component to change its Velocity value



        // Set Velocity (movement direction * speed)

        GetComponent<Rigidbody2D>().velocity = Vector2.up * h * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(h, v);




    }

    void Update()
    {

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Vertical1"));
        vertical = (int)(Input.GetAxisRaw("Horizontal1"));

        if (vertical != 0)
        {
            horizontal = 0;
        }

        Vector3 localScale = this.transform.localScale;
        Vector3 velocity = Vector3.zero;
        Vector3 newPosition = Vector3.zero;

        if (vertical != 0)
        {
            if (walkStartTime == 0)
            {
                walkStartTime = Time.time;
            }
            float speed = 0.05f;
            float dis = 0.1f;
            if (Time.time - walkStartTime > 2.0f)
            {
                speed = 0.03f;
                animator.SetTrigger("run");
            }
            else
            {
                animator.SetTrigger("walk");
            }
            if (isEvade)
            {
                speed = 0.01f;
                dis = 0.2f;
            }
            if (vertical > 0)
            {
                localScale.x = -Math.Abs(localScale.x);
                newPosition = this.transform.position + new Vector3(-dis, 0, 0);
            }
            else if (vertical < 0)
            {
                localScale.x = Math.Abs(localScale.x);
                newPosition = this.transform.position + new Vector3(dis, 0, 0);
            }

            this.transform.localScale = localScale;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, newPosition, ref velocity, speed);


        }


        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            walkStartTime = 0;
            animator.ResetTrigger("idle_1");
            animator.ResetTrigger("walk");
            animator.ResetTrigger("run");
            animator.ResetTrigger("jump");
            animator.SetTrigger("idle_1");
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    if (keyCode == KeyCode.H)
                    {
                        animator.SetTrigger("skill_1");
                    }
                    else if (keyCode == KeyCode.J)
                    {
                        animator.SetTrigger("skill_2");
                    }
                    else if (keyCode == KeyCode.K)
                    {
                        animator.SetTrigger("skill_3");
                    }
                    else if (keyCode == KeyCode.L)
                    {
                        animator.SetTrigger("idle_2");
                    }
                    else if (keyCode == KeyCode.Space)
                    {
                        animator.SetTrigger("evade_1");

                        StartCoroutine(Evade());

                    }
                }
            }
        }
    }

    public IEnumerator Evade()
    {
        yield return new WaitForSeconds(0.2f);
        isEvade = true;
        yield return new WaitForSeconds(0.2f);
        isEvade = false;
    }
    public GameObject ReplayButton;

    public bool GameOver1 { get; private set; }

    void OnCollisionEnter2D(Collision2D col)
    {
      GameOver1 = true;
    
        rb2d.velocity = Vector2.zero;
        //Set the ReplayButton to active to show it in the scene.
        ReplayButton.SetActive(true);
        //Change the isDead parameter of the Animator to start the Dead animation
        GetComponent<Animator>().SetBool("GameOver1", true);
        
    }
    public void Replay()
    {
        //This line changes the scene to the Scene 0 in your build settings
        SceneManager.LoadScene(0);
       
        


    }
}







