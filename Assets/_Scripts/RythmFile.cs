using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rhythm ", menuName = "Rhythms/Rhythm", order = 1)]
public class RythmFile : ScriptableObject
{
    public List<Melodi> drums = new List<Melodi>();
}

[System.Serializable]
public class Melodi
{
    [SerializeField] public bool[] drums;
}
