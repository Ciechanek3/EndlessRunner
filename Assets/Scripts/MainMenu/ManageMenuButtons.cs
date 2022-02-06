using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageMenuButtons : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
