using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGridController : MonoBehaviour
{

    public GameObject ShieldNotePrefab;
    public GameObject SwordNotePrefab;

    public float noteSpeed = 3.0f;

    //// grid points
    //// 0,0                          1,0                             2,0                             3,0
    //public GameObject G00Start;     public GameObject G10Start;     public GameObject G20Start;     public GameObject G30Start;
    //public GameObject G00End;       public GameObject G10End;       public GameObject G20End;       public GameObject G30End;

    //// 0,1                          1,1                             2,1                             3,1
    //public GameObject G01Start;     public GameObject G11Start;     public GameObject G21Start;     public GameObject G31Start;
    //public GameObject G01End;       public GameObject G11End;       public GameObject G21End;       public GameObject G31End;

    //// 0,2                          1,2                             2,2                             3,2
    //public GameObject G02Start;     public GameObject G12Start;     public GameObject G22Start;     public GameObject G32Start;
    //public GameObject G02End;       public GameObject G12End;       public GameObject G22End;       public GameObject G32End;

    public GameObject[] startPoints;
    public GameObject[] endPoints;

    private GameObject[] activeNotes;

    // Start is called before the first frame update
    void Start()
    {
        SpawnShieldNote(1, 1);
        SpawnSwordNote(2, 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNote(bool shield, int col, int row, int numPadRot)
	{

        // spawn position
        GameObject startPoint = startPoints[row * 4 + col];
        GameObject endPoint = endPoints[row * 4 + col];
        Vector3 spawnPos = startPoint.transform.position;

        // rotation
        Quaternion rot = GetQuatRotation(numPadRot);

        GameObject note;

        if (shield)
		{
            note = Instantiate(ShieldNotePrefab, spawnPos, rot);
		}
        else
		{
            note = Instantiate(SwordNotePrefab, spawnPos, rot);
		}

		//NoteController moveController = note.GetComponent<NoteController>();

		note.GetComponent<NoteController>().SetStartEndPoints(startPoint, endPoint);
        note.GetComponent<NoteController>().SetSpeed(noteSpeed);
		note.GetComponent<NoteController>().StartMove();
	}

    void SpawnShieldNote(int col, int row)
	{
        SpawnNote(true, col, row, 5);
	}

    void SpawnSwordNote(int col, int row, int numPadRot)
	{
        SpawnNote(false, col, row, numPadRot);
	}

    Quaternion GetQuatRotation(int numPadRot)
	{
        Quaternion quat = SwordNotePrefab.transform.rotation;

        //   <^   ^   ^>
        //     \  |  /
        //      7 8 9
        //   <- 4 5 6 ->
        //      1 2 3
        //     /  |  \
        //   <v   V   v>

        if (numPadRot == 7)
		{
            quat.eulerAngles = new Vector3(0, 0, 45);
		}
        else if (numPadRot == 8)
		{
            quat.eulerAngles = new Vector3(0, 0, 0);
		}
        else if (numPadRot == 9)
		{
            quat.eulerAngles = new Vector3(0, 0, -45);
		}
        else if (numPadRot == 4)
		{
            quat.eulerAngles = new Vector3(0, 0, 90);
		}
        else if (numPadRot == 5)
		{
            quat.eulerAngles = new Vector3(0, 0, 0);
		}
        else if (numPadRot == 6)
		{
            quat.eulerAngles = new Vector3(0, 0, -90);
		}
        else if (numPadRot == 1)
		{
            quat.eulerAngles = new Vector3(0, 0, 135);
		}
        else if (numPadRot == 2)
		{
            quat.eulerAngles = new Vector3(0, 0, 180);
		}
        else if (numPadRot == 3)
		{
            quat.eulerAngles = new Vector3(0, 0, -135);
		}

        return quat;
	}
}
