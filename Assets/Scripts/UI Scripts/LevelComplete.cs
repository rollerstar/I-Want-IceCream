using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    int activeScene;
   // public Animator anim;
    public AudioSource SFXSource;
    public AudioClip tranisitonClip;
    public GameObject winCanvas;
    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Awake()
    {
        //anim.SetTrigger("Transition");
        SFXSource.clip = tranisitonClip;
        SFXSource.Play();
    }


    public void FinishedPlaying()
    {
        winCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void NextDay()
    {
        SceneManager.LoadScene(activeScene + 1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
