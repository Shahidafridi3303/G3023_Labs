using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4;
    public LayerMask waterLayer;

    [SerializeField]
    Rigidbody2D rb;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         float x = Input.GetAxisRaw("Horizontal");
         float y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
             isMoving = true;

             animator.SetFloat("moveX", x);
             animator.SetFloat("moveY", y);
        }
        else
        {
            isMoving = false;
        }

        //animator.SetBool("isMoving", isMoving);


        Vector2 inputVector = new Vector2(x, y);
        Vector3 velocity = inputVector * moveSpeed;

        rb.velocity = velocity;

        CheckForEncounters();
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, waterLayer) != null)
        {
            Random random = new Random();
            int encounterChance = random.Next(1, 101);
            if (encounterChance <= 10)
            {
                Debug.Log("Encountered a wild Pokemon");
            }
        }
    }
}
