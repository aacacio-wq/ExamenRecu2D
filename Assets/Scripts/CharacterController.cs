using UnityEngine;
using UnityEngine.InputSystem;

public class Character_controller : MonoBehaviour
{
    
    float movementSpeed = 3f;
    InputAction _moveAction;
    InputAction _jumpAction;
    Vector2 _moveDirection;
    Rigidbody2D rigidbody2D;

    SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        _moveAction = InputSystem.actions ["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = _moveAction.ReadValue<Vector2>();

        if (_moveDirection.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (_moveDirection.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(_moveDirection.x * movementSpeed, rigidbody2D.linearVelocity.y);
    }
}
