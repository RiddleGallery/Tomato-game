using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSingleton : MonoBehaviour
{
    public static BGMSingleton BGMInstance { get; private set; }
    public static BGMSingleton Instance { get; private set; }
    private void Awake()
    {
        if (BGMInstance == null)
        {
            BGMInstance = this;

            DontDestroyOnLoad(gameObject);
        }
        else if (BGMInstance != this)
        {
            Destroy(gameObject);
        }

        
    }
    
}
