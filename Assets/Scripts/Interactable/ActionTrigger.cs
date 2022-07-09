using UnityEngine;
using System;

public class ActionTrigger : MonoBehaviour
{
    public Action OnActionPressed;

    public bool canBeUseOnlyOnce;

    private bool usedAlready;
    private bool playerInRange;

    [SerializeField] private GameObject visualCue;

    private void Update()
    {
        IconAppearsIfPlayerNear();

        if (InputManager.GetInstance().GetInteractPressed() && playerInRange)
        {
            OnActionPressed();

            if (canBeUseOnlyOnce)
                usedAlready = true;
        }
            
    }

    protected void IconAppearsIfPlayerNear()
    {
        if (!usedAlready)
        {
            if (playerInRange)
                visualCue.SetActive(true);
            else
                visualCue.SetActive(false);
        }
        else
            visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}