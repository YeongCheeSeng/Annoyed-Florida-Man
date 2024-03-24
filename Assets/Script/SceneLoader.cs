using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterScene : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextPage_1()
    {
        SceneManager.LoadScene("CutScene2");
    }

    public void NextPage_2()
    {
        SceneManager.LoadScene("CutScene3");
    }

    public void PreviousPage_2()
    {
        SceneManager.LoadScene("CutScene1");
    }

    public void PreviousPage_3()
    {
        SceneManager.LoadScene("CutScene2");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void FixedUpdate()
    {
        if (Cursor.visible == false)
            Cursor.visible = true;
    }
}