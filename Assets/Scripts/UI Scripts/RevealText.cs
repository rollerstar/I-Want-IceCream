using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RevealText : MonoBehaviour
{

    [SerializeField]
    [TextArea(15, 20)]
    string sentence;
    [SerializeField]
    float delay = 5f;
    [SerializeField]
    Text sentenceText;
    [SerializeField]
    AudioClip[] typingClip;
    [SerializeField]
    AudioSource source;
    public bool finishedTyping;
    void Awake()
    {
        sentenceText.text = "";

        StartCoroutine(revealText());
    }

    IEnumerator revealText()
    {
        yield return new WaitForEndOfFrame();

        foreach (char letter in sentence.ToCharArray())
        {
            sentenceText.text += letter;
            source.PlayOneShot(typingClip[Random.Range(0, 2)]);
            if (sentenceText.text.Length >= sentence.Length)
            {
                StopAllCoroutines();
                finishedTyping = !finishedTyping;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}