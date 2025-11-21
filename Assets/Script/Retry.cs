using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    [SerializeField] private Button RetryButton;
    public void RetryGame()
    {
        Debug.Log("Retry");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }
}
