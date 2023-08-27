using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;
public class Player : MonoBehaviour 
{
    public static float speed = 5.5f;
    public Rigidbody rb;
    public static float minY = -32;
    public static float maxY = 128;

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

    public void Die(string reason="died.")
    {
        Debug.Log(reason);
        SceneManager.LoadScene("Scenes/Menus/MainMenu");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("win")){
            Debug.Log("win");
            SceneManager.LoadScene("Scenes/Menus/MainMenu");
        }
    }

    private void Start() 
    {
        StartCoroutine(SetSkinTex(GetComponent<Renderer>()));
    }

    private void Update() {
        if(transform.position.y < minY)
        {  
            Die("fallen down.");
        }

        if(transform.position.y > maxY)
        {  
            Die("lost in space.");
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h*speed, 0, v*speed);
        rb.AddForce(movement);
    }
}