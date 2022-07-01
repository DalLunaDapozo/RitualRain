using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityCurrentRoom : MonoBehaviour
{
    public CurrentRoom entityCurrentRoom;

    public event EventHandler OntouchedTeleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision, "RitualRoom", CurrentRoom.RitualRoom);
        CheckCollision(collision, "Corridor", CurrentRoom.Corridor);
        CheckCollision(collision, "SecondFloorRoom", CurrentRoom.SecondFloorRoom);
        CheckCollision(collision, "LivingRoom", CurrentRoom.LivingRoom);

        CheckTeleportCollision(collision);
    }

    private void CheckTeleportCollision(Collider2D collision)
    {
        if (collision.CompareTag("Teleport"))
            OntouchedTeleport?.Invoke(this, EventArgs.Empty);
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

public enum CurrentRoom {RitualRoom, Corridor, SecondFloorRoom, LivingRoom } 