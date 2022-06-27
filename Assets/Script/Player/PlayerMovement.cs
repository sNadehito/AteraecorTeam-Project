using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody playerRb;
    public Animator playerAnim;
    public bool canPlayerMove = true;

    Vector3 playerMovement;

    [Header("Event")]
    public VoidEventChannelSO endingEventChannelSO;

    void Awake()
    {
        endingEventChannelSO.onEventRaised += playerCantMove;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused && canPlayerMove)
        {
            processInput();
        }
    }
    private void FixedUpdate()
    {
        playerMoving();
    }

    void processInput()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.z = Input.GetAxisRaw("Vertical");
        cancelAction();

        playerAnim.SetFloat("Horizontal", playerMovement.x);
        playerAnim.SetFloat("Vertical", playerMovement.z);
        playerAnim.SetFloat("Speed", playerMovement.sqrMagnitude);
    }

    void cancelAction()
    {
        if (playerAnim.GetBool("isPlayerAct") == true && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            FindObjectOfType<PlayerAction>().stopDelay();
            playerAnim.SetBool("isPlayerAct", false);
        }
    }

    void playerCantMove()
    {
        canPlayerMove = false;
    }

    void playerMoving()
    {
        Vector3 desiredPosition = playerMovement * moveSpeed * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + desiredPosition);
    }
    private void OnDestroy()
    {
        endingEventChannelSO.onEventRaised -= playerCantMove;
    }
}
