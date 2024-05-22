using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitText : MonoBehaviour
{
    public string text;
    public float speed;
    public int fadeSpeed;
    public byte fade = 255;
    public TextMeshProUGUI textObject;

    private void Start()
    {
        textObject.text = text;
    }

    void Update()
    {
        if (fade > 0)
        {
            transform.LookAt(Camera.main.transform);
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            fade -= (byte)fadeSpeed;
            textObject.faceColor = new Color32(255, 255, 255, fade);
        } else Destroy(gameObject);
    }
}
