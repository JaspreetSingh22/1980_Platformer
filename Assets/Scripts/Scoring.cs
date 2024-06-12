using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScrollsTotal;
    private void Start()
    {
        ScrollsTotal.text = "0" + PlayerPrefs.GetInt("TotalScrolls");
    }
}
