using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float max_speed;


    private Vector2 movement;
    private float drag_factor;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);   
    }
    
    private void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * max_speed * Time.deltaTime));
    }
}
