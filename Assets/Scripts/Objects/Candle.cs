using System;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] private ActionTrigger action;

    private Animator anim;

    public event EventHandler is_on_event;

    public bool is_on;

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
        is_on_event?.Invoke(this, EventArgs.Empty);
        is_on = true;
    }
}
