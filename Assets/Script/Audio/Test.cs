using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        MusicManager.Instance.PlayMusic("Fire",0);
       
    }
    void Sound()
    {
        SoundManager.Instance.PlaySound2D("01");
    }


}
