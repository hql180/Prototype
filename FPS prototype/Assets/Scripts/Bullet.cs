using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    [Space()]
    [Header("Bullet Properties")]
    [Tooltip("Damage value of bullet")]
    public int damage = 5;

    [Tooltip("How long bullet remains active before despawn")]
    public float maxLifeTime = 5;

    // Timer on bullet
    private float lifeTime;

	// Use this for initialization
	void Start ()
    {
        // Initializes timer
        lifeTime = maxLifeTime;
	}
	
    void OnCollisionEnter()
    {
        // Deactivates bullet on collision
        gameObject.SetActive(false);
    }

    public void ResetLifeTime()
    {
        lifeTime = maxLifeTime;
    }

	// Update is called once per frame
	void Update ()
    {
        // Updates timer if bullet is currently active
        if(gameObject.activeSelf)
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
                gameObject.SetActive(false);
	}
}
