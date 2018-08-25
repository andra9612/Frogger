using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMotor : MonoBehaviour {

    public float Speed { get; set; }
    [SerializeField] private bool isRightDirection;
    private Vector3 direction;
    private const float MAX_DISTANCE = 15f;
    private Vector3 startPosition;

    public delegate void OnSpriteDisable(GameObject disabledObject);
    public  event OnSpriteDisable SpriteDisableObserver;

    private void OnEnable()
    {
        startPosition = transform.position;
    }

    private void Start()
    {
        Debug.Log(Camera.main.rect.width);
        if (isRightDirection)
            direction = Vector3.right;
        else
            direction = Vector3.left;
    }

    void Update () {
        transform.Translate(direction * Speed * Time.deltaTime);

        if (Vector3.Distance(startPosition,transform.position) >= MAX_DISTANCE)
        {
            SpriteDisableObserver(gameObject);
            gameObject.SetActive(false);
        }
        
	}
}
