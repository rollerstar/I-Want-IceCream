using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float m_startingMinutes = 3.0f; //in seconds
    public bool m_startTimer = false;
    public Text m_timerLabel;
    public GameManager gameManager;
    private float m_miliseconds;
    private float m_seconds;
    private float m_mins;
    private float m_totalmiliseconds;
    private int timerActive;

    void Start()
    {
        this.Init(m_startingMinutes);
    }

    void Update()
    {
        if (m_startTimer && m_totalmiliseconds >= 0)
        {
            if (m_miliseconds <= 0)
            {
                if (m_seconds <= 0)
                {
                    m_mins--;
                    m_seconds = 59;
                }
                else
                {
                    m_seconds--;
                }

                m_miliseconds = 99;
            }

            m_miliseconds -= Time.deltaTime * 100;
            m_totalmiliseconds -= Time.deltaTime * 100;
        }
        else if (m_totalmiliseconds <= 0)
        {
            gameManager.TimesUp();
            gameObject.SetActive(false);
            m_miliseconds = 0.0f;
            m_seconds = 0.0f;
            m_mins = 0.0f;
            print("1");
        }

        if ((int)m_miliseconds > 9)
        {
            m_timerLabel.text = string.Format("{0}:{1}:{2}", m_mins, m_seconds, (int)m_miliseconds);
        }
        else
        {
            m_timerLabel.text = string.Format("{0}:{1}:0{2}", m_mins, m_seconds, (int)m_miliseconds);
        }
    }
    public void Init(float p_startingTime)
    {

        m_totalmiliseconds = p_startingTime * (60/*seconds*/) * (100/*miliseconds*/);
        m_mins = p_startingTime;
        m_startTimer = true;
    }

    public void PauseTimer(bool p_pause)
    {
        m_startTimer = p_pause;
        
    }
}