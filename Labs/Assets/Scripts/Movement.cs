using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private ParticleSystem dust;
    [SerializeField] float moveSpeed = 4;

    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        FadeEffect.Instance.StartFadeEffect();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 inputVector = new Vector2(x, y);
        Vector3 velocity = inputVector * moveSpeed;

        rb.velocity = velocity;

        if (velocity.x != 0 || velocity.y != 0)
        {
            CreateDust();
        }
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector3.zero;
    }

    void CreateDust()
    {
        dust.Play();
    }
}
