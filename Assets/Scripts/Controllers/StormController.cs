using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormController : MonoBehaviour
{

    [SerializeField] private EntityCurrentRoom player;

    [SerializeField] private float minTimeBetweenEvent;
    [SerializeField] private float maxTimeBetweenEvent;

    [SerializeField] private float timer;

    private bool eventOn;

    [SerializeField] private GameObject[] stormLights;

    public CurrentRoom playerCurrentRoom;

    private void Start()
    {
        eventOn = false;
        GenerateRandomNumber();
    }

    private void GenerateRandomNumber()
    {
        if (!eventOn)
            timer = Random.Range(minTimeBetweenEvent, maxTimeBetweenEvent);
    }
    private void Update()
    {
        TimerBetweenEvent();
        playerCurrentRoom = player.entityCurrentRoom;
    }
    private void TimerBetweenEvent()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
            StormEventTest();
    }

    private void StormEventTest()
    {
        eventOn = true;
       
        for (int i = 0; i < stormLights.Length; i++)
        {
            if (stormLights[i].GetComponent<EntityCurrentRoom>().entityCurrentRoom == playerCurrentRoom)
                stormLights[i].GetComponent<Animator>().SetTrigger("Storm");
        }
         
        eventOn = false;

        GenerateRandomNumber();

    }
}