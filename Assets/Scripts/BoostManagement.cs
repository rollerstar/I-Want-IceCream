using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoostManagement : MonoBehaviour
{
    public float originalWalkSpeed, boostSpeed, timer;
    public bool counting;
    public FirstPersonAIO player;
    [SerializeField]
    GameObject chocImg, timerTxt;
    [SerializeField]
    AudioSource Music;
    //CURRENTLY NOT WORKING
    //It does show the UI, increase the pitch of the sound and change the player controllers walk speed (it shows in editor)
    //And despite working in previous weeks, the character no longer moves fasters like they previously did?
    //INCOMPLETE, YET TO BE FIXED.
    //**Note:
    //Maybe just change the players POV to give it the illusion of going faster??
    void Start()
    {
        Music = GameObject. Find("Music").GetComponent<AudioSource>();
        player.walkSpeed = originalWalkSpeed;
        Reset();
    }
    private void Update()
    {
        if (counting)
        {
            timer -= Time.deltaTime;
            timerTxt.GetComponent<Text>().text = timer.ToString("F0");
            BoostSpeed();
        }
            

        if (timer <= 0)
        {
            counting = false;
            Reset();
        }

        chocImg.SetActive(true);
        
    }

    public void BoostSpeed()
    {
        print("Boosted!");
        chocImg.GetComponent<Image>().enabled = true;
        timerTxt.SetActive(true);
        player.walkSpeed = boostSpeed;
        counting = true;
        Music.pitch = 1.5f;
    }
    void Reset()
    {
        timer = 5;
        player.walkSpeed = originalWalkSpeed;
        chocImg.GetComponent<Image>().enabled = false;
        timerTxt.SetActive(false);
        timerTxt.GetComponent<Text>().text = "";
        Music.pitch = 1f;
    }
}