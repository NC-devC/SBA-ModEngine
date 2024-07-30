using System;
using System.IO;
using UnityEngine;

public class FileManager
{
    public static string getTextFromFile(string path)
    {   
        string formattedPath = Path.Combine(Application.streamingAssetsPath, path);
        Debug.Log(formattedPath);
        string fileContent = "-1";

        if (File.Exists(formattedPath))
        {
            using (StreamReader reader = new StreamReader(formattedPath))
            {
                fileContent = reader.ReadToEnd();
            }
        }
        else
        {
            Debug.LogError("File not found at path: " + formattedPath);
        }
        return fileContent;
    }
}