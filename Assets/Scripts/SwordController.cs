using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    public float accuracyThreshold;

    public Vector3 lastPos;
    public Vector3 currentPos;

    public Vector3 velocity;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lastPos = currentPos;
        currentPos = transform.position;
        velocity = currentPos - lastPos;
    }

	private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Sword collided with object");

        if (other.CompareTag("Sword"))
		{
            // compare note's direction with velocity of the sword swing
            Vector3 velocityNorm = velocity.normalized;
            Debug.Log("Normalized velocity vector for sword: " + velocityNorm);

            Vector3 noteDirNorm = other.transform.up.normalized;
            Debug.Log("Normalized up vector for sword note: " + noteDirNorm);

            float directionComparison = Vector3.Dot(velocityNorm, noteDirNorm);

            Debug.Log("Direction comparison: " + directionComparison);
            Debug.Log(accuracyThreshold);
            if (directionComparison >= accuracyThreshold)
			{
                Destroy(other.gameObject);
			}
		}
	}
}
