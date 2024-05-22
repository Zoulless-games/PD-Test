using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Text;
using System.IO;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int comboCount;
    public float perfectHitDistance;
    public float goodHitDistance;
    public int perfectHitScore;
    public int goodHitScore;
    public int badHitScore;
    public int notesHit;
    public int notesMissed;
    public GameObject hitText;

    public GameObject panel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI totalTimeText;
    public TextMeshProUGUI accuracyText;
    public bool songStarted;
    public float songDuration;
    public float timePlayed;
    public int accuracy;
    public Image timeline;
    public List<float> distanceFromCenter = new List<float>();
    public List<string> hitCondition = new List<string>();
    public List<int> comboOverTime = new List<int>();
    public List<int> accuracyOverTime = new List<int>();

    private bool dataSaved = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else Destroy(gameObject);
    }
    private void Update()
    {
        panel.transform.LookAt(Camera.main.transform);

        if (songStarted && timePlayed < songDuration)
        {
            timePlayed += Time.deltaTime;
            timeline.fillAmount = timePlayed / songDuration;

            int min = Mathf.FloorToInt(timePlayed / 60);
            int sec = Mathf.FloorToInt(timePlayed % 60);
            timeText.text = min.ToString("00") + ":" + sec.ToString("00");
        }

        if (!dataSaved && timePlayed > songDuration)
        {
            dataSaved = true;
            SaveData();
        }
    }

    public void SetTime()
    {
        int min = Mathf.FloorToInt(songDuration / 60);
        int sec = Mathf.FloorToInt(songDuration % 60);
        totalTimeText.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    public void Hit(float distance, GameObject drum)
    {
        comboCount++;
        notesHit++;

        if (distance <= perfectHitDistance)
        {
            score += perfectHitScore;
            SpawnText("Perfect!", drum, Color.magenta);
            hitCondition.Add("Perfect");
        }
        else if (distance <= goodHitDistance)
        {
            score += goodHitScore;
            SpawnText("Good", drum, Color.green);
            hitCondition.Add("Good");
        }
        else
        {
            score += badHitScore;
            SpawnText("Bad", drum, Color.yellow);
            hitCondition.Add("Bad");
        }

        scoreText.text = "Score\n" + score;
        comboText.text = "Combo\n" + comboCount;
        if (notesMissed > 0)
        {
            accuracy = (int)(((float)notesHit / (float)(notesMissed + notesHit)) * 100);
            accuracyText.text = $"Accuracy\n{accuracy.ToString("0")}%";
        }
        else
        {
            accuracy = 100;
            accuracyText.text = $"Accuracy\n{accuracy}%";
        }

        distanceFromCenter.Add(distance);
        comboOverTime.Add(comboCount);
        accuracyOverTime.Add(accuracy);
    }
    public void Miss(GameObject drum)
    {
        notesMissed++;
        comboCount = 0;
        comboText.text = "Combo\n" + comboCount;
        if (notesMissed > 0)
        {
            accuracy = (int)(((float)notesHit / (float)(notesMissed + notesHit)) * 100);
            accuracyText.text = $"Accuracy\n{accuracy.ToString("0")}%";
        }
        else
        {
            accuracy = 100;
            accuracyText.text = $"Accuracy\n{accuracy}%";
        }
        SpawnText("Missed", drum, Color.red);
        distanceFromCenter.Add(-1);
        hitCondition.Add("Missed");
        comboOverTime.Add(comboCount);
        accuracyOverTime.Add(accuracy);
    }

    public void SpawnText(string input, GameObject drum, Color color)
    {
        GameObject text = Instantiate(hitText, drum.transform.position, Quaternion.identity);
        text.GetComponent<HitText>().text = input;
        text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
    }


    public void SaveData()
    {
        string filePath = Application.dataPath + "/Data.csv";

        StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Note nr,Distance,Condition,Combo,Accuracy");

        for (int i = 0; i < distanceFromCenter.Count; ++i)
        {
            writer.WriteLine($"{i},{distanceFromCenter[i]},{hitCondition[i]},{comboOverTime[i]},{accuracyOverTime[i]}");
        }
        writer.Flush();
        writer.Close();
    }
}
