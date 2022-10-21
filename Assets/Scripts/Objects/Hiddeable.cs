using UnityEngine;
using System;

public class Hiddeable : MonoBehaviour
{

    [SerializeField] private GameObject highlight;
    [SerializeField] private PlayerController player;

    public bool player_near;
    public bool player_hidden;

    public bool correct_place_to_hide;

    private void Start()
    {
        highlight.SetActive(false);
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetInteractPressed())
        {
            InputManager.GetInstance().RegisterInteractPressed();
            if (player_near && !player_hidden)
            {
                player.Toggle_hide(false);
                player_hidden = true;

                if (correct_place_to_hide) player.is_well_hidden = true;

            }
            else 
            {
                player.Toggle_hide(true);
                player_hidden = false;

                if (correct_place_to_hide) player.is_well_hidden = false;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            player_near = true;
            highlight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player_near = false;
            highlight.SetActive(false);
        }
    }
}
