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

    public void changeColor(string colorStr)
    {
        Color color;
        switch(colorStr)
        {
            case "red":
            {
                color = Color.red;
                break;
            }
            case "green":
            {
                color = Color.green;
                break;
            }
            case "blue":
            {
                color = Color.blue;
                break;
            }
            case "black":
            {
                color = Color.black;
                break;
            }
            case "cyan":
            {
                color = Color.cyan;
                break;
            }
            case "grey":
            {
                color = Color.grey;
                break;
            }
            case "gray":
            {
                color = Color.gray;
                break;
            }
            case "magenta":
            {
                color = Color.magenta;
                break;
            }
            case "random":
            {
                color = Random.ColorHSV();
                break;
            }
            case "yellow":
            {
                color = Color.yellow;
                break;
            }
            default:
            {
                color = Color.white;
                break;
            }
        }
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    public void destroy()
    {
        GameObject.Destroy(this.gameObject);
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
    public void changeColor(string colorStr)
    {
        Color color;
        switch(colorStr)
        {
            case "red":
            {
                color = Color.red;
                break;
            }
            case "green":
            {
                color = Color.green;
                break;
            }
            case "blue":
            {
                color = Color.blue;
                break;
            }
            case "black":
            {
                color = Color.black;
                break;
            }
            case "cyan":
            {
                color = Color.cyan;
                break;
            }
            case "grey":
            {
                color = Color.grey;
                break;
            }
            case "gray":
            {
                color = Color.gray;
                break;
            }
            case "magenta":
            {
                color = Color.magenta;
                break;
            }
            case "random":
            {
                color = Random.ColorHSV();
                break;
            }
            case "yellow":
            {
                color = Color.yellow;
                break;
            }
            default:
            {
                color = Color.white;
                break;
            }
        }
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    public void destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}

[MoonSharpUserData]
public class LuaDIEPART
{
    public GameObject gameObject;
    public LuaDIEPART(GameObject newGO)
    {
        gameObject = newGO;
        Debug.Log("New die part");
    }
    public void changeColor(string colorStr)
    {
        Color color;
        switch(colorStr)
        {
            case "red":
            {
                color = Color.red;
                break;
            }
            case "green":
            {
                color = Color.green;
                break;
            }
            case "blue":
            {
                color = Color.blue;
                break;
            }
            case "black":
            {
                color = Color.black;
                break;
            }
            case "cyan":
            {
                color = Color.cyan;
                break;
            }
            case "grey":
            {
                color = Color.grey;
                break;
            }
            case "gray":
            {
                color = Color.gray;
                break;
            }
            case "magenta":
            {
                color = Color.magenta;
                break;
            }
            case "random":
            {
                color = Random.ColorHSV();
                break;
            }
            case "yellow":
            {
                color = Color.yellow;
                break;
            }
            default:
            {
                color = Color.white;
                break;
            }
        }
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    public void destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
}

[MoonSharpUserData]
public class SceneAPI
{
    public GameObject winPartPrefab;
    public GameObject diePartPrefab;
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
    public LuaDIEPART createDiePart(float x, float y, float z, float scaleX, float scaleY, float scaleZ)
    {
        GameObject diePart = GameObject.Instantiate(diePartPrefab, new Vector3(x, y, z), Quaternion.identity);
        diePart.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        LuaDIEPART luaDP = new LuaDIEPART(diePart);
        return luaDP;
    }
    
    public SceneAPI()
    {
        Debug.Log("Registering scene manager.");
    }
}