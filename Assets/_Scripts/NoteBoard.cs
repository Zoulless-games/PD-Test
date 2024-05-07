using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBoard : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public Material[] noteColors;
    public GameObject notePrefab;
    public float spawnRate;

    public List<GameObject> notesInHitArea = new List<GameObject>();

    private void Start()
    {
        //StartCoroutine(SpawnNote(Random.Range(0, spawnPoints.Length)));
    }

    public void AddNoteToHitArea(GameObject note)
    {
        notesInHitArea.Add(note);
    }

    public void RemoveNoteToHitArea(GameObject note)
    {
        Destroy(note);
        notesInHitArea.Remove(note);
    }

    public bool CheckIfNoteHit(int index)
    {
        int noteIndex = -1;
        for (int i = 0; i < notesInHitArea.Count; i++)
        {
            if (notesInHitArea[i].GetComponent<NoteScript>().index == index)
            {
                noteIndex = i;
                break;
            }
        }
        if (noteIndex != -1)
        {
            Destroy(notesInHitArea[noteIndex]);
            notesInHitArea.RemoveAt(noteIndex);
            return true;
        } return false;
    }

    public IEnumerator SpawnNote(int noteIndex)
    {
        GameObject spawnedNote = Instantiate(notePrefab);
        spawnedNote.GetComponent<NoteScript>().index = noteIndex;
        spawnedNote.transform.position = spawnPoints[noteIndex].transform.position;
        spawnedNote.GetComponent<Renderer>().material = noteColors[noteIndex];
        //yield return new WaitForSeconds(spawnRate / 1f);
        yield return null;
    }
}
