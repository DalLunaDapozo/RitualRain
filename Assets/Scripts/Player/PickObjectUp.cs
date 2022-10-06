using UnityEngine;

public class PickObjectUp : MonoBehaviour
{

    [SerializeField] private Transform hand_position;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            collision.GetComponent<Transform>().position = hand_position.position;
        }
    }
}
