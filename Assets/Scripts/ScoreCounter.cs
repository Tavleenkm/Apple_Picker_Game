using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // a


public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;  // b
    private Text uiText;  // c

    void Start()
    {
        uiText = GetComponent<Text>();  // d
    }

    void Update()
    {
        uiText.text = score.ToString("#,0");  // e
    }
}
