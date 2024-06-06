using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject settingsCanvas, mainCanvas, titleObj;
    [SerializeField]
    Text screenTxt, musicTxt, sfxTxt;
    [SerializeField]
    Slider slideSensitivity;
    [SerializeField]
    SoundManager soundManager;

    void Start()
    {

        //This resets the logic for when a player restarts a level.
        //When it is set to 1 the 'start screen/startObj' of a level won't appear so the player doesn't have to see the dialog 
        //everytime they fail a level.
        //This resets it so when they return to the main menu and start a new game, that the text will show.

        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.Save();

        //Set resolution for the sake the UI text size
        Screen.SetResolution(1280, 720, true);

        //Make sure the right Canvas objects are showing
        titleObj.SetActive(true);
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);

        //Changing the Settings Text based of previously saved PlayerPrefs
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            musicTxt.text = "Music: On";
        }
        else
        {
            musicTxt.text = "Music: Off";
        }

        if (PlayerPrefs.GetInt("SFX") == 0)
        {
            sfxTxt.text = "SFX: on";
        }
        else
        {
            sfxTxt.text = "SFX: Off";
        }
    }

    //MAIN MENU BUTTONS
    public void Play()
    {
        SceneManager.LoadScene(1);

    }

    public void Settings()
    {
        titleObj.SetActive(false);
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        titleObj.SetActive(true);
        mainCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        PlayerPrefs.Save();
    }

    //SETTINGS BUTTONS
    public void SFX()
    {

        if (PlayerPrefs.GetInt("SFX") == 0)
        {
            PlayerPrefs.SetInt("SFX", 1);
            sfxTxt.text = "SFX: Off";
        }
        else
        {
            PlayerPrefs.SetInt("SFX", 0);
            sfxTxt.text = "SFX: On";
        }

        soundManager.CheckSFX();

    }

    public void Music()
    {

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            musicTxt.text = "Music: On";
        }
        else
        {
            PlayerPrefs.SetInt("Music", 0);
            musicTxt.text = "Music: Off";
        }

        soundManager.CheckMusic();

    }

    public void Windowed()
    {
        if(Screen.fullScreen == true)
        {
            Screen.SetResolution(1280, 720, false);
        }
        else
        {
            Screen.fullScreen = true;
        }

        if(Screen.fullScreen  == false)
        {
            screenTxt.text = "Fullscreen";
        }
        else
        {
            screenTxt.text = "Windowed";
        }
    }
}