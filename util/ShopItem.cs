using System;
using System.Collections;
using System.Collections.Generic;
using entity.mob;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using util;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private MobType mobType;
    private TextMeshProUGUI costText;
    private TextMeshProUGUI typeText;

    private GameObject entity;
    private EntityManager entityManager;

    private void Start()
    {
        
        
        entityManager = GameObject.Find("EntityManager").GetComponent<EntityManager>();
        
        typeText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        costText = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        
        typeText.SetText(mobType.ToString());
        costText.SetText(((int) mobType).ToString());
    }

    public void Buy()
    {
        if (!entityManager.BuyAlly(mobType))
        {
            Debug.Log("caqnt buy!!");
        }
        
    }
}
