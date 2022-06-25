using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody playerRb;
    public Animator playerAnim;

    Vector3 playerMovement;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        processInput();

    }
    private void FixedUpdate()
    {
        playerMoving();
    }

    void processInput()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.z = Input.GetAxisRaw("Vertical");

        playerAnim.SetFloat("Horizontal", playerMovement.x);
        playerAnim.SetFloat("Vertical", playerMovement.z);
        playerAnim.SetFloat("Speed", playerMovement.sqrMagnitude);
    }

    void playerMoving()
    {
        playerRb.MovePosition(playerRb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
