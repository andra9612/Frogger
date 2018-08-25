using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogHealth : MonoBehaviour {

    [SerializeField] private int health;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            if (health <= 0)
                Debug.Log("GameOver");
        }
    }


}
