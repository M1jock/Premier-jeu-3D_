using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour ,ICollectable
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
        Destroy(this.gameObject);
    }
    IEnumerator CollectCorout()
    {
        coinAudioSource.Play();
        visual.SetActive(false);

        while (coinAudioSource.isPlaying)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
    private void OnDestroy()
    {
        Score.instance.AddScore(point);
    }
}
