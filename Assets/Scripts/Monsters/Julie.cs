using UnityEngine;
using System.Collections;
using System;

public class Julie : MonoBehaviour
{
    [SerializeField] private Transform spawnPointMirrorWorld;
    [SerializeField] private Transform spawnPointBathroom;

    [SerializeField] private PlayerController player;

    private bool mazeDone;

    private void Start()
    {
        DialogueManager.GetInstance().On_Dialogue_Exit += On_Close_Dialogue;
    }

    private void On_Close_Dialogue(object sender, EventArgs e)
    {
        bool hasSaidYesToMirror = ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("mirror")).value;
        if (hasSaidYesToMirror) StartCoroutine(TeleportPlayerToMirrorWorld());
    }


    private IEnumerator TeleportPlayerToMirrorWorld()
    {
        InputManager.GetInstance().DisableInput();

        SceneController.instance.PlayAnimation("fade_in");

        yield return new WaitForSeconds(SceneController.instance.anim.GetCurrentAnimatorStateInfo(0).length + 2f);

        player.TeleportPlayer(spawnPointMirrorWorld.position);
        SceneController.instance.PlayAnimation("fade_out");

        yield return new WaitForSeconds(SceneController.instance.anim.GetCurrentAnimatorStateInfo(0).length);

        InputManager.GetInstance().EnableInput();
    }
}
