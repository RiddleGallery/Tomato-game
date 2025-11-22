using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ShowHighscoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;
    private string _highscore = "000";
    // this script shows the highscore saved in the SaveSystem and show specific ui object for each ending that player unlocked
    // so we need to get the ui oject from the inspector and set active true for the specific one
    private bool _highscoreLoaded = false;
    [SerializeField] private GameObject _goodEndUI;
    [SerializeField] private GameObject _normalEndUI;
    [SerializeField] private GameObject _happyEndUI;
    public static bool GoodEndUnlocked = false;
    public static bool NormalEndUnlocked = false;
    public static bool HappyEndUnlocked = false;

    void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "HIGH_SCORE.sav");
        if (
            File.Exists(path) &&
            !_highscoreLoaded
        )
        {
            _highscore = File.ReadAllText(path);
            _highscoreText.text = _highscore;
            _highscoreLoaded = true;
        }

        if (GoodEndUnlocked)
        {
            _goodEndUI.SetActive(true);
        }
        else { _goodEndUI.SetActive(false); }
        if (NormalEndUnlocked)
        {
            _normalEndUI.SetActive(true);
        }
        else { _normalEndUI.SetActive(false); }
        if (HappyEndUnlocked)
        {
            _happyEndUI.SetActive(true);
        }
        else { _happyEndUI.SetActive(false); }


    }

    // get score from gamemanager then compare with saved highscore and update if it is higher
    public void Update()
    {
        int currentScore = GameManager.Instance._score;
        int savedHighscore = int.Parse(_highscore);
        if (currentScore > savedHighscore)
        {
            _highscore = currentScore.ToString("D3");
            _highscoreText.text = _highscore;
            SaveSystem.SaveHighscore(_highscore);
        }
    }

    }


