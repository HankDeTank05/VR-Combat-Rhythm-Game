using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickScript : MonoBehaviour
{
    public GameObject noteGrid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Sword") || other.CompareTag("Shield"))
		{
            Debug.Log("time delay = " + noteGrid.GetComponent<AudioSource>().time);
		}
	}
}
