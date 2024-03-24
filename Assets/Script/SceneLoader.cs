using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterScene : MonoBehaviour
{
    public string SceneName;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    private void FixedUpdate()
    {
        if (Cursor.visible == false)
            Cursor.visible = true;
    }
}