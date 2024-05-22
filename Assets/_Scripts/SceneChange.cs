using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
