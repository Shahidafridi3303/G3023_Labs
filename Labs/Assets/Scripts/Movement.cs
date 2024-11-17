using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4;

    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    public void HandleUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 inputVector = new Vector2(x, y);
        Vector3 velocity = inputVector * moveSpeed;

        rb.velocity = velocity;
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector3.zero;
    }
}
