using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighscoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private string highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscoreText.text = highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
