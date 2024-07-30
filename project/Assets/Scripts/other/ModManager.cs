using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;

public class ModManager
{
    public static string skinName = "defaultskin";

    public string SkinPathByName(string skinName)
    {
        string url = Path.Combine(Application.streamingAssetsPath, "Images/Skins/"+skinName+".png");
        if (File.Exists(url))
        {
            return url;
        }
        url = Path.Combine(Application.streamingAssetsPath, "Images/Skins/"+"defaultskin.png");
        return url;
    }
}