using MoonSharp.Interpreter;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class LuaLevel : MonoBehaviour 
{
    public static Script globalScript;
    public static bool hasGlobalScript = false;
    string globalScriptCode = "";

    bool canCallUpdate = true;
    bool canCallFUpdate = true;
    bool canCallES = true;

    public SceneAPI sa;

    public GameObject winPart;

    public int sceneTime = 0;

    string log(string text)
    {
        Debug.Log(text);
        return "true";
    } 

    public IEnumerator timer(){
        while(true){
            yield return new WaitForSeconds(1);
            sceneTime+=1;
            sa.time = sceneTime;
            if(canCallES)
            {
                EverySecondLua();
            }
        }
    }

    public void initLuaScript(Script script)
    {
        script.Globals["print"] = (Func<string, string>)log;
        script.Globals["sa"] = sa;
    }

    public void prepareScripts()
    {
        string code = FileManager.getTextFromFile("Scripts/Global/globalScript.lua");
        UserData.RegisterAssembly();
        if(code == "-1")
        {
        }
        else
        {
            globalScript = new Script();
            globalScriptCode = code;
            hasGlobalScript = true;
            initLuaScript(globalScript);
            DynValue res = globalScript.DoString(code);
        }
    }

    public void OnCreateLua()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("Start"));
            }
            catch
            {
                Debug.Log("Can't call create!");
            }
        }
    }

    public void OnUpdateLua()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("Update"));
                canCallUpdate = true;
            }
            catch
            {
                canCallUpdate = false;
            }
        }
    }

    public void EverySecondLua()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("EverySecond"));
                canCallES = true;
            }
            catch
            {
                canCallES = false;
            }
        }
    }

    public void OnFixedUpdateLua()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("FixedUpdate"));
                canCallFUpdate = true;
            }
            catch
            {
                canCallFUpdate = false;
            }
        }
    }

    public static void OnWin()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("OnWin"));
            }
            catch
            {
            }
        }
    }

    public static void OnDie()
    {
        if(hasGlobalScript)
        {
            try
            {
                DynValue res = globalScript.Call(globalScript.Globals.Get("OnDie"));
            }
            catch
            {
            }
        }
    }

    private void Start() 
    {
        sa = new SceneAPI();
        sa.winPartPrefab = winPart;
        sceneTime = 0;
        prepareScripts();
        OnCreateLua();
        OnUpdateLua();
        OnFixedUpdateLua();
        EverySecondLua();
        StartCoroutine(timer());
    }

    private void Update() 
    {
        if(canCallUpdate)
        {
            OnUpdateLua();
        }
    }

    private void FixedUpdate() 
    {
        if(canCallFUpdate)
        {
            OnFixedUpdateLua();
        }
    }
}