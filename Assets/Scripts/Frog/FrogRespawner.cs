using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogRespawner : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Respawner.RespawnPlayer();
    }
}
