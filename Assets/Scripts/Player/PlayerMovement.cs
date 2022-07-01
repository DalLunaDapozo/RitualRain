using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float VelocidadDeMovimiento;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetLighterPressed())
        {
            Debug.Log("DALEEE");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(InputManager.GetInstance().GetMoveDirection().x, 
                                  InputManager.GetInstance().GetMoveDirection().y) * VelocidadDeMovimiento * Time.deltaTime;
    }
}
