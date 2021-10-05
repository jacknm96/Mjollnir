using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    static public TMP_Text instance;
    [SerializeField] TMP_Text itemDisplay;
    public static List<Collectables> coins = new List<Collectables>();

    private void Start()
    {
        instance = itemDisplay;
        UpdateDisplay();
    }

    public static void Restart()
    {
        foreach (Collectables coin in coins)
        {
            coin.gameObject.SetActive(true);
            Collectables.collectablesCollected = 0;
            UpdateDisplay();
        }
    }

    public static void UpdateDisplay()
    {
        instance.text = Collectables.collectablesCollected.ToString() + "/" + Collectables.maxCollectable.ToString() + " coins";
    }

    public static void VictoryMessage()
    {
        instance.text = "You Win!";
    }
}
