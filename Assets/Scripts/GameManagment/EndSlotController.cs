using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSlotController : MonoBehaviour
{

   
    public delegate void OnEndSlotFilled(Transform slot);
    public static event OnEndSlotFilled EndSlotFiledObserver;



    private void OnTriggerEnter(Collider other)
    {

        if (transform.GetChild(0).gameObject.activeSelf)
        {
            Debug.Log("Death");
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            EndSlotFiledObserver(transform);
        }
       
    }
}
