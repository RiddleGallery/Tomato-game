using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _tutorialButton;
    [SerializeField] private Button _highScoreButton;
    [SerializeField] private Button _exitButton;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        Debug.Log("working");
        SceneManager.LoadScene("MainGame");
    }

    public void Tutorial()
    {
        Debug.Log("working");
        SceneManager.LoadScene("ControlTutorial");
    }

    public void Highscore()
    {
        Debug.Log("working");
        SceneManager.LoadScene("ScorePage");
    }

    public void Exit()
    {
        Debug.Log("working");
        Application.Quit();
    }
}
