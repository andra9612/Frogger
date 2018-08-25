using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -1);
    }
}
