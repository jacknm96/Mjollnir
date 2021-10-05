using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectables : MonoBehaviour
{
    public static int maxCollectable;
    public static int collectablesCollected;
    [SerializeField] UnityEvent pickUpEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        maxCollectable++;
        Display.coins.Add(this);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collected();
        }
    }

    void Collected()
    {
        collectablesCollected++;
        pickUpEvent.Invoke();
        Display.UpdateDisplay();
        CheckAllCollected();
        gameObject.SetActive(false);
    }

    void CheckAllCollected()
    {
        if (collectablesCollected == maxCollectable)
        {
            Display.VictoryMessage();
        }
    }
}
