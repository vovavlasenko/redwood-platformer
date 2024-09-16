using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Loot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _amountText;

    public static event Action LootCollected;

    [HideInInspector] public int BonusAmount;

    public void InitializeAmount(int amount)
    {
        BonusAmount = amount;
        _amountText.SetText(BonusAmount.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddLootToPlayer(collision.gameObject);
            LootCollected?.Invoke();
            Destroy(gameObject);
        }
    }

    public abstract void AddLootToPlayer(GameObject player);
}
