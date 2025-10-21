using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private TMP_Text _Timer;

    [SerializeField] private Image _healthDisplay;
    [SerializeField] private List<Sprite> _healthSprites;

    [SerializeField] private Image _OverlayDisplay;
    [SerializeField] private List<Sprite> _OverlaySprite;


    [SerializeField] private float _SpawnerInGame;
    private int _health;
    private int _score;

    private float _timeLim = 120f;
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
       // _OverlayDisplay.sprite = _OverlaySprite[_health];
        _score = 0;

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
            NormalEnd();
        }
    }

    private void NormalEnd()
    {
        EndGame();
        // calculate final score
    }

    private void EndGame()
    {
        if (_isGameOver) return;
        _isGameOver = true;
        Time.timeScale = 0f;

    }

    public void InactiveSpawner(int increment)
    {
       // _SpawnerInGame -= increment;
        // check if all spawners are deactivated
        if (_SpawnerInGame <= 0)
        {
            GoodEnd();
        }
    }
    public void Hurt(int damage)
    {
        _health += damage;
        _healthDisplay.sprite = _healthSprites[_health];
     //   _OverlayDisplay.sprite = _OverlaySprite[_health];
        if (_health >= 4)
        {
            BadEnd();
        }
    }
    private void GoodEnd()
    {
        EndGame();
        // active good end UI
    }
    private void BadEnd()
    {
        EndGame();
        // active bad end UI
    }


}
