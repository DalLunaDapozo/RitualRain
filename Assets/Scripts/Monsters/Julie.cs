using UnityEngine;
using System.Collections;
using System;

public class Julie : MonoBehaviour
{
    [SerializeField] private Transform spawnPointMirrorWorld;
    [SerializeField] private Transform spawnPointBathroom;

    [SerializeField] private PlayerController player;

    private bool mazeDone;

    private void Awake()
    {
        player.BackToBathroom += TeleportBackToBathroom;
    }

    private void Start()
    {
        DialogueManager.GetInstance().On_Dialogue_Exit += On_Close_Dialogue;
    }

    private void On_Close_Dialogue(object sender, EventArgs e)
    {
        bool hasSaidYesToMirror = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("mirror")).value;
        if (hasSaidYesToMirror) StartCoroutine(TeleportPlayer(spawnPointMirrorWorld));
    }


    private void TeleportBackToBathroom(object sender, EventArgs e)
    {
        mazeDone = true;
        StartCoroutine(TeleportPlayer(spawnPointBathroom));
   
    }

    private IEnumerator TeleportPlayer(Transform teleport_to)
    {
        InputManager.GetInstance().DisableInput();

        InputManager.GetInstance().SetMovementToZero();

        SceneController.instance.PlayAnimation("fade_in", 1f);

        yield return new WaitForSeconds(SceneController.instance.anim.GetCurrentAnimatorStateInfo(0).length + 2f);

        player.TeleportPlayer(teleport_to.position);
        SceneController.instance.PlayAnimation("fade_out", 1f);

        yield return new WaitForSeconds(SceneController.instance.anim.GetCurrentAnimatorStateInfo(0).length);

        InputManager.GetInstance().EnableInput();

        if (mazeDone) Destroy(gameObject);
    }
}
