using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyKillCount : MonoBehaviour
{
    public int count;
    public static EnnemyKillCount instance;
    public void Awake()
    {
        instance = this;
    }
    public static void AddKill()
    {
        instance.count++;
    }
}
