using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NmbrHp : MonoBehaviour
{
    public TextMeshProUGUI HealthNmbrText;
    public static NmbrHp instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthNmbrText = GetComponent<TextMeshProUGUI>();
    }
    public void textUpdate()
    {
        HealthNmbrText.text = PlayerController.instance.currentHealth + "/" + PlayerController.instance.maxHealth;  
    }
}
