using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{

    public float speed = 1.0f;

    public GameObject point1;
    public GameObject point2;

    private GameObject target;

    public bool moveFlag = false;

    private Vector3 vectDist;
    private float linearDist;

    public float destroyDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = point2;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveFlag == true)
		{
            MoveObject();

            vectDist = transform.position - target.transform.position;
            linearDist = vectDist.magnitude;
            if (linearDist <= destroyDistance)
			{
                Destroy(gameObject);
			}
		}
    }

    void MoveObject()
	{
        /////////////////////
        // MOVE THE OBJECT //
        /////////////////////

        Vector3 direction = target.transform.position - gameObject.transform.position;
        direction.Normalize();

        direction *= Time.deltaTime;

        direction *= speed;

        gameObject.transform.position += direction;
	}

    public void SetStartEndPoints(GameObject start, GameObject end)
	{
        point1 = start;
        point2 = end;
        target = point2;
	}

    public void SetSpeed(float setSpeed)
	{
        speed = setSpeed;
	}

    public void StartMove()
	{
        moveFlag = true;
	}

    public void StopMove()
	{
        moveFlag = false;
	}
}
