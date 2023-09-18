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
    public static float maxY = 256;
    public FixedJoystick joystick;
    public bool isLuaLevel = false;

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
        if(isLuaLevel)
        {
            LuaLevel.OnDie();
        }
        SceneManager.LoadScene("Scenes/Menus/MainMenu");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("win")){
            Debug.Log("win");
            if(isLuaLevel)
            {
                LuaLevel.OnWin();
            }
            SceneManager.LoadScene("Scenes/Menus/MainMenu");
        }
        if(other.gameObject.CompareTag("die")){
            Debug.Log("die");
            if(isLuaLevel)
            {
                LuaLevel.OnDie();
            }
            SceneManager.LoadScene("Scenes/Menus/MainMenu");
        }
    }

    private void Start() 
    {
        try
        {
            if(Build.mobile == true)
            {
                joystick.gameObject.active = true;
            }
            else
            {
                joystick.gameObject.active = false;
            }
        }
        catch 
        {
        }
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

        if(Build.mobile == true)
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;

            Vector3 movement = new Vector3(h*speed, 0, v*speed);
            rb.AddForce(movement);
        }

        float hI = Input.GetAxis("Horizontal");
        float vI = Input.GetAxis("Vertical");

        Vector3 movementI = new Vector3(hI*speed, 0, vI*speed);
        rb.AddForce(movementI);
    }
}