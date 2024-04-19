using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField]
    AudioSource coinAudioSource;

    [SerializeField]
    GameObject visual;

    public int point;
    public static Coin instance;
    private void Awake()
    {
        instance = this;
    }
    public void OnCollected()
    {
        StartCoroutine(CollectCorout());
    }
    IEnumerator CollectCorout()
    {
        coinAudioSource.Play();
        visual.SetActive(false);

        while (coinAudioSource.isPlaying)
        {
            yield return null;
        }
        Score.instance.AddScore(point);
        Destroy(this.gameObject);



    }
}
