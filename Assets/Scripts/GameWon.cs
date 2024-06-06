using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    [SerializeField]
    RevealText txt;
    [SerializeField]
    GameObject canvas, player;

    private void Start()
    {
        player.SetActive(false);
    }

    void Update()
    {
        if(txt.finishedTyping == true && Input.GetButton("Fire1"))
        {
            player.SetActive(true);
            canvas.SetActive(false);
            txt.finishedTyping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
