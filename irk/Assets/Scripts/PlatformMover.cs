using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum PLATFORMDIRECTION
{
    HORIZONTAL, VERTICAL
}

public class PlatformMover : MonoBehaviour
{
    public PLATFORMDIRECTION platformDirection = PLATFORMDIRECTION.VERTICAL;
    public float minPos = -10f;
    public float maxPos = 10f;
    public float moveSpeed = 3f;

    private float currentX = 0;
    private float currentY = 0;

    void Start()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;
        DOTween.Init(true, false);
        if(platformDirection == PLATFORMDIRECTION.VERTICAL)
            GoUp();
        else
            GoLeft();
    }

    private void GoUp()
    {
        transform.DOMove(new Vector3(currentX,maxPos,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoDown);
    }

    private void GoDown()
    {
        transform.DOMove(new Vector3(currentX,minPos,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoUp);
    }

    private void GoLeft()
    {
        transform.DOMove(new Vector3(maxPos,currentY,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoRight);
    }

    private void GoRight()
    {
        transform.DOMove(new Vector3(minPos,currentY,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoLeft);
    }
}
