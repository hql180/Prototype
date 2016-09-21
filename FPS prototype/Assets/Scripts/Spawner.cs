using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    [Space()]
    [Tooltip("Prefab of object to spawn")]
    public Transform spawnObject;

    [Space()]
    [Tooltip("Maximum number of spawns on the screen")]
    public int length = 10; 

    private Transform[] pool; // Pre-allocate game objects to improve performance

    // Use this for initialization
    void Start ()
    {
        // Allocating objects to pool according to length
        pool = new Transform[length];
        for(int i = 0; i < length; ++i)
        {
            Transform thing = Instantiate(spawnObject);
            pool[i] = thing;
            thing.gameObject.SetActive(false);
            //thing.hideFlags = HideFlags.HideInHierarchy;
        }
	}

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Fire2"))
        {
            Transform thing = null;

            // Loops through object pool to find an inactive object to spawn
            for (int i = 0; i < pool.Length; ++i) 
            {
                if (!pool[i].gameObject.activeSelf)
                {                                    
                    thing = pool[i];
                    pool[i].gameObject.SetActive(true);
                    break;
                }
            }

            if (thing != null)
            {
                // Resets forces on object before setting spawn point to spawn location
                thing.GetComponent<Cube>().Reset();                
                thing.GetComponent<Rigidbody>().velocity = Vector3.zero;                
                thing.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                thing.position = transform.position;
                thing.rotation = transform.rotation;                
            }        

        }
	}
}
