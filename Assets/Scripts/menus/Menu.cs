using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;

public class Menu : MonoBehaviour
{
    public GameObject ball;

    IEnumerator SetSkinTex(Renderer renderer)
    {
        ///url = Application.dataPath + "/StreamingAssets/shareImage.png";
        var url = Path.Combine(Application.streamingAssetsPath, "Images/Skins/defaultskin.png");

        byte[] imgData;
        Texture2D tex = new Texture2D(100, 100);

        //Check if we should use UnityWebRequest or File.ReadAllBytes
        if (url.Contains("://") || url.Contains(":///"))
        {
            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            imgData = www.downloadHandler.data;
        }
        else
        {
            imgData = File.ReadAllBytes(url);
        }

        //Load raw Data into Texture2D 
        tex.LoadImage(imgData);

        renderer.material.mainTexture = tex;
    }

    public void Levels(int id)
    {
        SceneManager.LoadScene("Scenes/levels/level"+id);
    }

    private void Start() 
    {
        StartCoroutine(SetSkinTex(ball.GetComponent<Renderer>()));
    }
}
