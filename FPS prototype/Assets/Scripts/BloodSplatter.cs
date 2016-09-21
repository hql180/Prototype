using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodSplatter : MonoBehaviour
{
    [SerializeField]
    private Image bloodTexture;

    private bool displayBlood = false;

    private Color alpha = new Color(1, 1, 1, 0);

    public float bloodTimer = 5;

    private float alphaTimer;

	// Use this for initialization
	void Start ()
    {
        alphaTimer = bloodTimer;
        bloodTexture.color = alpha;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            sampleTrigger();
        }

        // Checks whether to display blood or not
        if (displayBlood)
        {
            alpha.a = 1f * ((alphaTimer -= Time.deltaTime) / bloodTimer) + (Mathf.Sin(alphaTimer*3) * .15f);

            Debug.Log(alpha.a);

            bloodTexture.color = alpha;

           
        }
    }          


    IEnumerator StopBloodDisplay()
    {
        yield return new WaitForSeconds(bloodTimer);

        displayBlood = false;

        alpha.a = 0;

        bloodTexture.color = alpha;
    }

    public void sampleTrigger()
    {
        displayBlood = true;

        alpha.a = 1f;

        StartCoroutine(StopBloodDisplay());
    }
}
