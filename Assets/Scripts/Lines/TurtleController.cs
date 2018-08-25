using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : MonoBehaviour {

    private Animator animator;
    private const string ANIMATOR_PARAM = "UnderWater";
    private const float TIMER = 5f;
    private bool animationParamState = false;
    private WaitForSeconds waitForSeconds;

    private void Start()
    {
        animator = GetComponent<Animator>();
        waitForSeconds = new WaitForSeconds(TIMER);
        StartCoroutine(PlayTurtleAnimation());
    }

    private IEnumerator PlayTurtleAnimation()
    {
        animationParamState = !animationParamState;
        yield return waitForSeconds;
        animator.SetBool(ANIMATOR_PARAM, animationParamState);
        if (transform.childCount > 0)
            Respawner.RespawnPlayer();
        StartCoroutine(PlayTurtleAnimation());
    }
}
