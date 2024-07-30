using MoonSharp.Interpreter;
using UnityEngine;
using UnityEngine.UI;

[MoonSharpUserData]
public class LuaText
{
    public float posX;
    public float posY;
    public float scaleX;
    public float scaleY;
    public int fontSize = 24;
    public Text textComponent;
    public GameObject gameObject;
    public string textStr;
    public LuaText(float posX, float posY, int fontSize, float scaleX, float scaleY, string text)
    {
        this.posX = posX;
        this.posY = posY;
        this.fontSize = fontSize;
        this.scaleX = scaleX;
        this.scaleY = scaleY;
        this.textStr = text;
        Debug.Log("Created lua text.");
    }
    public void destroy()
    {
        GameObject.Destroy(this.gameObject);
    }
    public void changeText(string newText)
    {
        textComponent.text = newText;
        textStr = newText;
    }
}

[MoonSharpUserData]
public class GuiAPI
{
    public Canvas canv;

    public LuaText createText(float x, float y, int fontSize, float scaleX, float scaleY, string text)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(canv.transform);

        Text textComponent = textObject.AddComponent<Text>();
        textComponent.text = text;
        textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        textComponent.fontSize = fontSize;
        textComponent.rectTransform.position = new Vector2(x,y);

        LuaText lT = new LuaText(x,y,fontSize,scaleX,scaleY, text);
        lT.gameObject = textObject;
        lT.textComponent = textComponent;

        return lT;
    }

    public GuiAPI(Canvas canvas)
    {
        Debug.Log("Registering gui api.");
        this.canv = canvas;
    }
}