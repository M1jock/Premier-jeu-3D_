using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public int coins;

    public float time;

    public int ennemyKilled;
    public static PersistantData instance;

    public void GetInfo()
    {
        //coins = ScoreCoin.instance.score;

    }

    private void Awake()
    {
        if (instance != null&& instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void ResetValue()
    {
        time = 0;
        coins = 0;
        ennemyKilled = 0;
    }

}
