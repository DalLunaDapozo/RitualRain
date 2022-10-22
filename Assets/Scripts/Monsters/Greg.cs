using System.Collections;
using System;
using UnityEngine;
using TMPro;

public class Greg : MonoBehaviour
{

    [SerializeField] private TextMeshPro numberPopUp;
    [SerializeField] private GameObject cue;
    [SerializeField] private PlayerController player;

    public event EventHandler player_is_well_hidden;
    public event EventHandler player_is_not_well_hidden;

    private bool hasListened = false;

    private void Awake()
    {
        player.on_player_hidden += Start_Hide_Seek;
    }

    private void Update()
    {
        bool hasSaidYesToHide = ((Ink.Runtime.BoolValue)DialogueManager.
        GetInstance().GetVariableState("game_accepted")).value;

        if (!hasListened && hasSaidYesToHide)
        {
            Debug.Log("EMPIEZA EL JUEGO");
            hasListened = true;
        }
    }

    private void Start_Hide_Seek(object sender, EventArgs e)
    {
        if (!player.is_well_hidden)
        {
            player_is_not_well_hidden?.Invoke(this, EventArgs.Empty);
        } 
        else
        {
            player_is_well_hidden?.Invoke(this, EventArgs.Empty);
        }
           
    }

}
