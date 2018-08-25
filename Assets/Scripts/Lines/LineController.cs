using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    [SerializeField] private PoolController[] poolControllers;
    [SerializeField] private float timer;
    [SerializeField] private float speed;
    private WaitForSeconds waitForSeconds;

	void Start () {
        waitForSeconds = new WaitForSeconds(timer);
        LevelController.MultiplierIncreaseObserver += ChangeSpeed;
        StartCoroutine("SpawnPrefabs");
    }
	
    private IEnumerator SpawnPrefabs()
    {
        yield return waitForSeconds;
        poolControllers[Random.Range(0, poolControllers.Length)].PopGameObject(transform.position, speed);
        StartCoroutine("SpawnPrefabs");
    }

    private void ChangeSpeed(float multiplier)
    {
        speed += multiplier;
    }


}
