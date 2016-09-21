using UnityEngine;
using System.Collections;

public class RandomiseColour : MonoBehaviour
{
    public GameObject target;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Randomise()
    {
        target.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.value, Random.Range(.8f, 1f), Random.Range(.8f, 1f));
    }
}
