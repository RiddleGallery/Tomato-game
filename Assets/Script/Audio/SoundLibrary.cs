using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string GroupID;
    public AudioClip[] clips;
    public AudioSource sources;
};
public class SoundLibrary : MonoBehaviour
{
    public static SoundManager instance;
    public SoundEffect[] soundEffects;
    public AudioClip GetClipFromName(string name)
    {
        foreach (var soundEffect in soundEffects)
        {

            return soundEffect.clips[Random.Range(0, soundEffect.clips.Length)];
        }
        return null;


    }
}
