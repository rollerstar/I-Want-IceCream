using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayOpening : MonoBehaviour
{
    [SerializeField]
    [TextArea(15, 20)]
    string sentence;
    [SerializeField]
    float delay = 5f;
    [SerializeField]
    Text sentenceText;
    [SerializeField]
    GameObject player, manager, startCanvas;
    [SerializeField]
    AudioClip[] typingClip;
    [SerializeField]
    AudioClip continueClip;
    [SerializeField]
    AudioSource source, musicSource;
    bool canContinue;
    int newGame;

    void Start()
    {
        if(PlayerPrefs.GetInt("NewGame") == 0)
        {
            sentenceText.text = "";
            manager.GetComponent<Timer>().enabled = false;
            StartCoroutine(revealText());
        }
        else
        {
            Continue();
        }
    }

    void Update() 
    {
        if(Input.GetButton("Fire1") && canContinue == true)
        {
            source.PlayOneShot(continueClip);
            Continue();
        }    
    }

    IEnumerator revealText()
    {
        yield return new WaitForEndOfFrame();

        foreach (char letter in sentence.ToCharArray())
        {
            //yield return new WaitForEndOfFrame();
            sentenceText.text += letter;
            source.PlayOneShot(typingClip[Random.Range(0,2)]);
            if(sentenceText.text.Length >= sentence.Length)
            {
                StopAllCoroutines();
                canContinue = true;
            }  
            yield return new WaitForSeconds(delay);
        }
    }

    void Continue()
    {
        player.GetComponent<FirstPersonAIO>().enabled = (true);
        manager.GetComponent<Timer>().enabled = true;
        startCanvas.SetActive(false);
        musicSource.Play();
    }
}