using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    [Space()]
    [Tooltip("Max Health of cube")]
    public int maxHealth = 200;

    private int currentHealth;

    // Float to store orginal mass of object
    private float maxMass;

    // Stores references to rigidBody component
    private Rigidbody objRef;

	// Use this for initialization
	void Start ()
    {
        // Sets current health to max health
        currentHealth = maxHealth;

        objRef = gameObject.GetComponent<Rigidbody>();

        // Stores original mass value
        maxMass = objRef.mass;
	}
	
    void OnCollisionEnter(Collision collision)
    {
        // Checks for collision with bullets
        if(collision.collider.tag == "Bullet")
        {
            if (currentHealth > 0)
            {
                // Reduces cube health according to bullet damage
                currentHealth -= collision.gameObject.GetComponent<Bullet>().damage;

                // Starts despawn timer on cube
                if (currentHealth <= 0)
                    StartCoroutine(DeactivateCube(gameObject, 5f));

                // Makes cube lighter as cube takes more damage
                if (objRef != null && currentHealth < maxHealth)
                {
                    objRef.mass = maxMass * ((float)currentHealth / (float)maxHealth);
                }
            }
        }
    }

    // Function to despawn cube based on timer
    IEnumerator DeactivateCube(GameObject cube, float time)
    {

        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        if (objRef != null)
        {
            currentHealth = maxHealth;
            objRef.mass = maxMass;
        }
    }

	// Update is called once per frame
	void Update ()
    {
      
    }
}
