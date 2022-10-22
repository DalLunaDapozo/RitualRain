using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayFootstep : MonoBehaviour
{
    public void PlayFootstepSound()
    { 
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Footstep", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("carpet")) return; //PLAY TAL SONIDO;
    }
   
}
