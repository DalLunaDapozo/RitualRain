using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] protected GameObject visualCue;

    protected bool playerInRange;
    [SerializeField] protected bool canBeUseOnlyOnce;

    protected bool usedAlready;

    protected virtual void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
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
    protected void CheckIfPlayerIsNear(Collider2D collider, bool trueOrFalse)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = trueOrFalse;
        }
    }

    protected bool GetPlayerInRange()
    {
        return playerInRange;
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfPlayerIsNear(collision, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckIfPlayerIsNear(collision, false);
    }

}
