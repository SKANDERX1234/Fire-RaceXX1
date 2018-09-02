using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundScroller : MonoBehaviour
{
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag=="Player"){
            
            transform.position +=2* Vector3.right * GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

        
    }
