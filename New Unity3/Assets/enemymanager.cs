using UnityEngine;

public class enemymanager : MonoBehaviour
{
          
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;
    private int i = 0;
    public int number = 5;// An array of the spawn points this enemy can spawn from.


    private void Update()
    {
        if (i >= number)
            CancelInvoke("Spawn");
        
      


    }

    void Start()
    {
        transform.Rotate(Vector3.forward * 90);
        // Call the Spawn  after a delay of the spawnTime and then continue to call after the same amount of time.
           InvokeRepeating("Spawn", spawnTime, spawnTime);
       
        }


    void Spawn()
    {
      
        // If the player has no health left...
        

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //transform.Rotate(Vector3.forward * 90);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        i++;
        
    }

    
        
        
    }
