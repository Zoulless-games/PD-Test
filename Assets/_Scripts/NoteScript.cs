using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public float speed;
    public int index;
    public float margin;

    public GameObject drum;
    public bool autoPlay;

    private void Update()
    {
        transform.position = transform.position - transform.forward * speed * Time.deltaTime;
        if (drum != null)
        {
            if (transform.position.z >= (drum.transform.position.z - margin) && transform.position.z <= (drum.transform.position.z + margin))
            {
                drum.GetComponent<ValueChanger>().DrumHit(index);
                GameObject.Find("NoteBoard").GetComponent<NoteBoard>().CheckIfNoteHit(index);
                ScoreManager.instance.Hit(Vector3.Distance(new Vector3(0, 0, drum.transform.GetComponent<ValueChanger>().note.transform.position.z), new Vector3(0, 0, drum.transform.position.z)), drum.gameObject);
                drum = null;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoteDeath"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("NoteHit"))
        {
            if(autoPlay) drum = other.transform.parent.gameObject;
            GameObject.Find("NoteBoard").GetComponent<NoteBoard>().AddNoteToHitArea(gameObject);
            other.transform.parent.GetComponent<ValueChanger>().note = gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NoteHit"))
        {
            GameObject.Find("NoteBoard").GetComponent<NoteBoard>().RemoveNoteToHitArea(gameObject);
            ScoreManager.instance.Miss(other.transform.parent.gameObject);
            other.transform.parent.GetComponent<ValueChanger>().note = null;
        }
    }
}
