using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject closedDoor;
    [SerializeField] private GameObject openDoor;

    public void OpenDoor()
    {
        openDoor.SetActive(true);
        closedDoor.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            OpenDoor();
            Destroy(collision.gameObject);
        }
    }
  
}

