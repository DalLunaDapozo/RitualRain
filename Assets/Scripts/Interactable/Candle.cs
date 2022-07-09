using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private ActionTrigger action;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        action.OnActionPressed += TurnOn;
    }

    private void OnDestroy()
    {
        action.OnActionPressed -= TurnOn;
    }

    private void TurnOn()
    {
        anim.enabled = true;
    }
}
