using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class MusicPlayer : MonoBehaviour
{
    public string musicName = "defaultSong";
    public static string musicStatic;
    private AudioSource audioSource;

    private string getMusicLocation()
    {
        string retVal = "file://";
        string p = Path.Combine(Application.streamingAssetsPath, "Music/"+musicName+".mp3");
        retVal = p;
        return retVal;
    }

    IEnumerator PlaySong()
    {
        WWW loadedFile = new WWW(getMusicLocation());

        yield return loadedFile;

        if (loadedFile.error != null) 
        {
            Debug.Log ("Error, Path: " + loadedFile.url);
        } 
        else 
        {
            audioSource.clip = loadedFile.GetAudioClip(true, false);
            audioSource.Play();
        }
    }

    private void Start() 
    {
        musicStatic = musicName;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySong());
    }
}
