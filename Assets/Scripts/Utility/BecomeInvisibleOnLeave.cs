using System;
using UnityEngine;

public class BecomeInvisibleOnLeave : MonoBehaviour
{
    [SerializeField] private EntityCurrentRoom player_location;
    [SerializeField] private GameObject sprite;


    private void Awake()
    {
        player_location.OnChangeRoom += CheckIfInRoom;   
    }

    private void CheckIfInRoom(object sender, EventArgs e)
    {
        if (player_location.entityCurrentRoom == CurrentRoom.Bathroom || 
            player_location.entityCurrentRoom == CurrentRoom.Bedroom  ||
            player_location.entityCurrentRoom == CurrentRoom.Closet) sprite.gameObject.SetActive(true);  
        else sprite.gameObject.SetActive(false);  
    }

}
