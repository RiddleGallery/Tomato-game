using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMMainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update


    public static BGMMainMenuScript Instance;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pizzaC;
    [SerializeField] private AudioClip _fire;

    [SerializeField] private bool _playFire;
    [SerializeField] private bool _playPizzaC;

    //[SerializeField] private GameManager _gameManager;

    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // If one exists, destroy this new duplicate and return
            Destroy(gameObject);
            return;
        }

        // Set the instance to this object
        Instance = this;

        // This command prevents the object from being destroyed when changing scenes
        DontDestroyOnLoad(gameObject);



        _audioSource = GetComponent<AudioSource>();
        SceneManager.activeSceneChanged += OnSceneChanged;
        




    }

    private void PlayNewMusic (AudioClip clip)
    {

            _audioSource.clip = clip;
            _audioSource.Play();
            /*_isPlaying = true;
            
            if (BGMInstance != null   )
            {
                _audioSource.enabled = true;
               
            }*/

            /*if (BGMInstance == this)
            {
                Debug.Log("using this one");

            }
            else
            {
                Debug.Log("something when wrong");
            }*/
            
        
        
    }

    

    private void OnSceneChanged(Scene current, Scene next)
    {
        

        if (next.name == "MainGame")
        {
            Debug.Log("Playing fire");
            
            _audioSource.Stop();

            _audioSource.volume = 0.25f;
            PlayNewMusic(_fire);
            
        }
        else
        {
            Debug.Log("Playing pizzac");
            _audioSource.volume = 1f;
            PlayNewMusic(_pizzaC);
        }
    }
}
