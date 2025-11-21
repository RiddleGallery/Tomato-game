using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BackButtonScript : MonoBehaviour
{
    [SerializeField] private Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        Debug.Log("working");
        SceneManager.LoadScene("MainMenu");
    }
}
