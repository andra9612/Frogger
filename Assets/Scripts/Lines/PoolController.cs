using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{

    private Stack<GameObject> objectStack;
    // Use this for initialization
    void Start()
    {
        objectStack = new Stack<GameObject>();
        PutAllGameObjectsToStack();
    }

    private void PutAllGameObjectsToStack()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            objectStack.Push(transform.GetChild(i).gameObject);
        }
    }

    private void PushDisabledGameObkect(GameObject disabledObject)
    {
        disabledObject.GetComponent<SpriteMotor>().SpriteDisableObserver -= PushDisabledGameObkect;
        objectStack.Push(disabledObject);
    }

    public void PopGameObject(Vector3 startPosition, float speed)
    {
        if (objectStack.Count > 0)
        {
            GameObject objectFromStack = objectStack.Pop();
            SpriteMotor motor = objectFromStack.GetComponent<SpriteMotor>();
            objectFromStack.transform.position = startPosition;
            motor.Speed = speed;
            motor.SpriteDisableObserver += PushDisabledGameObkect;
            objectFromStack.SetActive(true);
        }
    }
}
