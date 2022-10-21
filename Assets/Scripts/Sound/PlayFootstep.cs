using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayFootstep : MonoBehaviour
{
    public void PlayFootstepSound()

    { 
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Footstep", gameObject);
    }

    void MaterialCheck()

    { 
    
    }
}
