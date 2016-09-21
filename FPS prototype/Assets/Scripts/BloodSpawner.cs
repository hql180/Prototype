using UnityEngine;
using System.Collections;

public class BloodSpawner : MonoBehaviour
{
    public Transform prefab;

	// Use this for initialization
	void Start ()
    {
	
	}
	
    void OnCollisionEnter(Collision collision)
    {
        // Checks for collision with bullets
        if (collision.collider.tag == "Bullet")
        {
            Transform emiter = Instantiate(prefab);
            emiter.position = collision.transform.position;
            emiter.parent = transform;
            emiter.LookAt(transform.position - collision.relativeVelocity);
            //emiter.GetComponent<ParticleSystem>().Play();
        }
    }

    void OnDisable()
    {
        foreach (var particle in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            Destroy(particle.gameObject);
        }
        
    }

	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 10000000))
        //    {
        //        Transform emiter = Instantiate(prefab);
        //        emiter.position = hit.point;
        //        emiter.parent = hit.transform;
        //        emiter.LookAt(hit.point + hit.normal * 10, Vector3.up);
        //    }
        //}
    }
}
