using UnityEngine;
using System;

public class EntityCurrentRoom : MonoBehaviour
{
    public CurrentRoom entityCurrentRoom;

    public event EventHandler OntouchedTeleport;
    public event EventHandler OnChangeRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AllTheRoomsInTheGame(collision);
        CheckTeleportCollision(collision);
        OnChangeRoom?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        AllTheRoomsInTheGame(collision);
        CheckTeleportCollision(collision);
    }

    private void CheckTeleportCollision(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
            OntouchedTeleport?.Invoke(this, EventArgs.Empty);
    }

    private void AllTheRoomsInTheGame(Collider2D collision)
    {
        CheckCollision(collision, "RitualRoom", CurrentRoom.RitualRoom);
        CheckCollision(collision, "Corridor", CurrentRoom.Corridor);
        CheckCollision(collision, "SecondFloorRoom", CurrentRoom.SecondFloorRoom);
        CheckCollision(collision, "LivingRoom", CurrentRoom.LivingRoom);
        CheckCollision(collision, "UpstairsBedroom", CurrentRoom.UpstairsBedroom);
        CheckCollision(collision, "Kitchen", CurrentRoom.Kitchen);
        CheckCollision(collision, "Storage", CurrentRoom.Storage);
        CheckCollision(collision, "Backyard", CurrentRoom.Backyard);
        CheckCollision(collision, "Library", CurrentRoom.Library);
        CheckCollision(collision, "Bedroom", CurrentRoom.Bedroom);
        CheckCollision(collision, "Bathroom", CurrentRoom.Bathroom);
        CheckCollision(collision, "Closet", CurrentRoom.Closet);
        CheckCollision(collision, "MirrorWorld_1", CurrentRoom.MirrorWorld_1);
        CheckCollision(collision, "MirrorWorld_2", CurrentRoom.MirrorWorld_2);
        CheckCollision(collision, "MirrorWorld_3", CurrentRoom.MirrorWorld_3);
    }

    private void CheckCollision(Collider2D collision, string tag, CurrentRoom newCurrentRoom)
    {
        if (collision.CompareTag(tag))
            entityCurrentRoom = newCurrentRoom;
    }

    public CurrentRoom GetCurrentRoom()
    {
        return entityCurrentRoom;
    }
}

public enum CurrentRoom {RitualRoom, Corridor, SecondFloorRoom, LivingRoom, UpstairsBedroom, 
                         Kitchen, Storage, Backyard, Bedroom, Closet, Library, Bathroom, MirrorWorld_1, MirrorWorld_2, MirrorWorld_3} 