using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMotor : MonoBehaviour
{
    private CharacterController character;
    private Animator animator;
    private const string PARAM_STATE = "IsJump";
    private const float MOVING_DELAY = 0.1f;
    private const float WATER_Y_POS = 0.5f;
    private float savedRotation;
    private KeyCode pressedKey;
    private WaitForSeconds waitForSeconds;

    void Start()
    {
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
        waitForSeconds = new WaitForSeconds(MOVING_DELAY);
        savedRotation = 0f;
        pressedKey = KeyCode.None;
    }

    void Update()
    {

        if (CheckIsItNeedToMove())
        {
            
            RotateCharacter();
            MoveCharacter();
            StartCoroutine("GetDeleyAfterJump");
        }

    }

    private IEnumerator GetDeleyAfterJump()
    {
        yield return new WaitForSeconds(MOVING_DELAY);
        animator.SetBool(PARAM_STATE, false);
        if (transform.parent == null && transform.position.y > WATER_Y_POS)
            Respawner.RespawnPlayer();
    }


    private void RotateCharacter()
    {
        float currentRotation = 0f;
        switch (pressedKey)
        {
            case KeyCode.W:
                currentRotation = 0f;
                break;
            case KeyCode.S:
                currentRotation = 180f;
                break;
            case KeyCode.D:
                currentRotation = 270f;
                break;
            case KeyCode.A:
                currentRotation = 90f;
                break;
        }

        if (currentRotation != savedRotation)
        {
            savedRotation = currentRotation;
            transform.rotation = Quaternion.Euler(0, 0, savedRotation);
        }

    }

    private void MoveCharacter()
    {
        character.Move(transform.up);
    }

    private bool CheckIsItNeedToMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
            pressedKey = KeyCode.W;
        else if (Input.GetKeyDown(KeyCode.S))
            pressedKey = KeyCode.S;
        else if (Input.GetKeyDown(KeyCode.D))
            pressedKey = KeyCode.D;
        else if (Input.GetKeyDown(KeyCode.A))
            pressedKey = KeyCode.A;
        else
            return false;
        animator.SetBool(PARAM_STATE, true);
        return true;
    }
}
