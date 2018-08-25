using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

    private static Vector3 playerStartPosition;
    private static Transform player;
    private static FrogHealth frogHealth;

    void Start()
    {
        playerStartPosition = GameObject.Find("PlayerStartPosition").transform.position;
        player = GameObject.Find("Frog").transform;
        frogHealth = player.GetComponent<FrogHealth>();
    }

    public static void RespawnPlayer()
    {
        player.position = playerStartPosition;
        frogHealth.Health -= 1;
    }
}
