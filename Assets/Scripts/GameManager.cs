using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int iceCreams = 0, totalIceCreams;
    public Text iceCreamsTxt;
    public WorldSpawner worldSpawner;
    public AudioSource SFXsource, musicSource;
    [SerializeField]
    AudioClip carHitClip, levelCompleteClip, timesUpClip;
    [SerializeField]    
    GameObject player, deadScreen, timesUpScreen, wonScreen;


    void Start()
    {
        if(PlayerPrefs.GetInt("SFX") == 0)
        {
            SFXsource.volume = 1.0f;
        }
        else
        {
            SFXsource.volume = 0f;
        }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicSource.volume = 1.0f;
        }
        else
        {
            musicSource.volume = 0f;
        }

        totalIceCreams = worldSpawner.numStores;
    }

    void Update()
    {   
        iceCreamsTxt.text = iceCreams.ToString() + " / " + totalIceCreams.ToString();
    }

    public void TimesUp()
    {
        musicSource.Stop();
        SFXsource.clip = timesUpClip;
        SFXsource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<FirstPersonAIO>().enabled = false;
        timesUpScreen.SetActive(true);
    }

    public void CheckWin()
    {
        if(iceCreams >= totalIceCreams)
        {
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        musicSource.Stop();
        SFXsource.clip = levelCompleteClip;
        SFXsource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<FirstPersonAIO>().enabled = false;
        wonScreen.SetActive(true);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.Save();
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(activeScene + 1);
    }

    public void CarHit()
    {
        musicSource.Stop();
        SFXsource.clip = carHitClip;
        SFXsource.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<FirstPersonAIO>().enabled = false;
        deadScreen.SetActive(true);
    }
}
