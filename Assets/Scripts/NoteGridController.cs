using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGridController : MonoBehaviour
{

	public GameObject ShieldNotePrefab;
    public GameObject SwordNotePrefab;

    public float noteSpeed = 3.0f;

    public GameObject[] startPoints;
    public GameObject[] endPoints;

    public Vector4[] songNotes; // X = column, Y = row, Z = songTime, W = numpad rotation, with 5 being a shield note

    private GameObject[] activeNotes;

    private float songStartTime = -1.0f;
    private bool songPlaying = false;
    private int indexOfNextNote = 0;

    AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();

        StartSong();
    }

    // Update is called once per frame
    void Update()
    {
		if (songPlaying)
		{
            if (song.time >= songNotes[indexOfNextNote].z)
			{
                SpawnNote(songNotes[indexOfNextNote]);
                indexOfNextNote++;
                if (indexOfNextNote > songNotes.Length)
				{
                    StopSong();
				}
			}
		}
    }

    void SpawnNote(Vector4 noteVect)
	{
        int col = (int)noteVect.x;
        int row = (int)noteVect.y;
        float songTime = noteVect.z;
        int numPadRot = (int)noteVect.w;

        // spawn position
        GameObject startPoint = startPoints[row * 4 + col];
        GameObject endPoint = endPoints[row * 4 + col];
        Vector3 spawnPos = startPoint.transform.position;

        // rotation
        Quaternion rot = GetQuatRotation(numPadRot);

        GameObject note;

        if (numPadRot == 5)
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

    void StartSong()
    {
        //songStartTime = Time.time;
        songPlaying = true;
        song.Play();
    }

    void PauseSong()
	{
        song.Pause();
	}
    
    void StopSong()
	{
        //songStartTime = -1.0f;
        songPlaying = false;
        song.Stop();
	}
}
