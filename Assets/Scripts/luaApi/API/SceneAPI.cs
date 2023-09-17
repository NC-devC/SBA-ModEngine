using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class LuaCUBE
{
    public GameObject gameObject;
    public LuaCUBE(GameObject newGO)
    {
        gameObject = newGO;
        Debug.Log("New cube");
    }

    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
}

[MoonSharpUserData]
public class LuaWINPART
{
    public GameObject gameObject;
    public LuaWINPART(GameObject newGO)
    {
        gameObject = newGO;
        Debug.Log("New win part");
    }
    public void destroy()
    {
        GameObject.Destroy(gameObject);
    }
}

[MoonSharpUserData]
public class SceneAPI
{
    public GameObject winPartPrefab;
    public int time;

    public static LuaCUBE createCube(float x, float y, float z, float scaleX, float scaleY, float scaleZ)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(x, y, z);
        cube.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        LuaCUBE luaCube = new LuaCUBE(cube);
        return luaCube;
    }

    public LuaWINPART createWinPart(float x, float y, float z, float scaleX, float scaleY, float scaleZ)
    {
        GameObject winPart = GameObject.Instantiate(winPartPrefab, new Vector3(x, y, z), Quaternion.identity);
        winPart.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        LuaWINPART luaWP = new LuaWINPART(winPart);
        return luaWP;
    }
    
    public SceneAPI()
    {
        Debug.Log("Registering scene manager.");
    }
}