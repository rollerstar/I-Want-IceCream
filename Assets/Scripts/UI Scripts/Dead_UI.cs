using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead_UI : MonoBehaviour
{
    Scene scene;
    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public void TryAgain()
    {
        PlayerPrefs.SetInt("NewGame", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(scene.name);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.Save();
    }
}
