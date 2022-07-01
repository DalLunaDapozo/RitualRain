using UnityEngine;
using System;

public class TeleportController : MonoBehaviour
{
    [Header("Entities")]

    [SerializeField] private EntityCurrentRoom player;

    [Header("Stairs")]

    [SerializeField] private GameObject secondFloorSpawnPoint;
    [SerializeField] private GameObject firstFloorSpawnPoint;

    private bool playerIsSecondFloor;

    private void OnEnable()
    {
        player.OntouchedTeleport += TeleportPlayerStairs;
    }

    private void Update()
    {
        IsPlayerUpstairs();
    }

    private void TeleportPlayerStairs(object sender, EventArgs e)
    {
        if (IsPlayerUpstairs())
            TeleportGameObject(player.gameObject, firstFloorSpawnPoint);
        else
            TeleportGameObject(player.gameObject, secondFloorSpawnPoint);
    }

    public void TeleportGameObject(GameObject objectToTeleport, GameObject pointToGo)
    {
        objectToTeleport.transform.position = new Vector3(pointToGo.transform.position.x,
                                                          pointToGo.transform.position.y, 0f);
    }
    
    private bool IsPlayerUpstairs()
    {
        if (player.entityCurrentRoom == CurrentRoom.RitualRoom ||
            player.entityCurrentRoom == CurrentRoom.Corridor ||
            player.entityCurrentRoom == CurrentRoom.SecondFloorRoom)
            playerIsSecondFloor = true;
        else
            playerIsSecondFloor = false;


        return playerIsSecondFloor;
    }

}
