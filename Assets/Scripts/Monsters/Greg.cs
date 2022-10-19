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
    private bool hasCounted = false;

    private bool you_didnt_hide;

    public int count;

    private void Start()
    {
        you_didnt_hide = false;
        ((Ink.Runtime.IntValue)DialogueManager.
        GetInstance().GetVariableState("countTimeBeforePlay")).value = count;
    }

    private void Update()
    {
        bool hasSaidYesToHide = ((Ink.Runtime.BoolValue)DialogueManager.
        GetInstance().GetVariableState("hide")).value;


        if (!hasListened && hasSaidYesToHide)
        {
            StartCoroutine(CountSequence());
            Debug.Log("EMPIEZA EL JUEGO");
            hasListened = true;
        }

        if (hasCounted)
        {
            if (player.is_hidden)
            {
                if (!player.is_well_hidden) player_is_not_well_hidden?.Invoke(this, EventArgs.Empty);
                else player_is_well_hidden?.Invoke(this, EventArgs.Empty);
            }
            else you_didnt_hide = true;

            hasCounted = false;
        }
    }

    private IEnumerator CountSequence()
    {
        cue.SetActive(false);
        numberPopUp.gameObject.SetActive(true);
    
        while (count > -1)
        {
            numberPopUp.text = count--.ToString();
            yield return new WaitForSeconds(1f);
        }

        numberPopUp.gameObject.SetActive(false);
      
        hasCounted = true;
    }
}
