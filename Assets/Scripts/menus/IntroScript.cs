using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    private void Start()
    {
        //В будущем тут будет загрузка модов ваще круто
        SceneManager.LoadScene("Scenes/Menus/MainMenu");
    }
}
