using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField] private Player p;

    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private TMP_Text _Timer;

    [SerializeField] private Image _healthDisplay;
    [SerializeField] private List<Sprite> _healthSprites;

    [SerializeField] private Image _OverlayDisplay;
    [SerializeField] private List<Sprite> _OverlaySprite;

    [SerializeField] private Image _badEnd;
    [SerializeField] private Image _happyEnd;
    [SerializeField] private Image _goodEnd;
    [SerializeField] private Image _normalEnd;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backButton;

    

     private float _SpawnerInGame = 4f;
    private int _health;
    private int _score;



     private int _scoreThreshold = 50;

    private float _timeLim = 95f;
    bool _isGameOver;

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        
        

        _health = 0;
        _healthDisplay.sprite = _healthSprites[_health];
        _OverlayDisplay.sprite = _OverlaySprite[_health];
        _score = 0;


    }
    private void Start()
    {
        
        _OverlayDisplay.enabled = false;
        _badEnd.gameObject.SetActive(false);
        _happyEnd.gameObject.SetActive(false);
        _goodEnd.gameObject.SetActive(false);
        _normalEnd.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);

    }
    void Update()
    {
        CountDown();
    }


    public void AddScore(int increment)
    {
        _score += increment;
        UpdateScoreLabel();
    }
    public void UpdateScoreLabel()
    {

        _scoreLabel.text = _score.ToString();
    }

    private void CountDown()
    {
        _timeLim -= Time.deltaTime;

        _Timer.text = (_timeLim - (_timeLim% 1)).ToString();
        if (_timeLim <= 0f)
        {
            if (_score >= _scoreThreshold)
            {
                GoodEnd();
            }
            else
            {
                NormalEnd();
            }
                
        }
    }


    private void NormalEnd()
    {
        EndGame();
        ShowHighscoreScript.NormalEndUnlocked = true;
        _normalEnd.gameObject.SetActive(true);
    }

    private void EndGame()
    {
        if (_isGameOver) return;
        PlayerPrefs.SetInt("LastScore", _score);
        _isGameOver = true;
        Time.timeScale = 0f;
        
        _restartButton.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(true);
    }

    public bool ReturnEndGame()
    {
        return _isGameOver;
    }

    public void InactiveSpawner(int increment)
    {
       _SpawnerInGame -= increment;
        // check if all spawners are deactivated
        if (_SpawnerInGame <= 0)
        {
            HappyEnd();
        }
    }
    public void Hurt(int damage)
    {
        _OverlayDisplay.enabled = true;
        
        _health += damage;
        p.GotHurt();
        int spriteIndex = _health;
        spriteIndex = Mathf.Clamp(spriteIndex, 0, _healthSprites.Count - 1);
        int sIOverlay = _health;
        sIOverlay = Mathf.Clamp(sIOverlay, 0, _OverlaySprite.Count - 1);

        _healthDisplay.sprite = _healthSprites[spriteIndex];
        _OverlayDisplay.sprite = _OverlaySprite[sIOverlay];
        if (_health >= 4)
        {           
            BadEnd();
        }
    }
    private void GoodEnd()
    {
        EndGame();
        ShowHighscoreScript.GoodEndUnlocked = true;
        _goodEnd.gameObject.SetActive(true);
    }
    private void BadEnd()
    {
        EndGame();
        _badEnd.gameObject.SetActive(true);
    }

    private void HappyEnd()
    {
        EndGame();
        ShowHighscoreScript.HappyEndUnlocked = true;
        _happyEnd.gameObject.SetActive(true);
    }



}
