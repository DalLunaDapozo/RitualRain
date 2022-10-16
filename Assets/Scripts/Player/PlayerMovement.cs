using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float movementSpeed;

    [SerializeField] private float VelocidadDeMovimientoNormal;
    [SerializeField] private float VelocidadDeMovimientoEnStealth;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ChangeMovementSpeedDependingIfStealth();
    }

    private void FixedUpdate()
    {
        rb.velocity = InputManager.GetInstance().GetMoveDirection() * movementSpeed * Time.deltaTime;
    }

    public void SetMovementToZero()
    {
        InputManager.GetInstance().SetMovementToZero();
    }

    private void ChangeMovementSpeedDependingIfStealth()
    {
        if (LighterController.lightIsOn)
            movementSpeed = VelocidadDeMovimientoNormal;
        else
            movementSpeed = VelocidadDeMovimientoEnStealth;
    }
}
