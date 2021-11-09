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

    private float startX = 0;
    private float startY = 0;
    private float currentX = 0;
    private float currentY = 0;

    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        currentX = transform.position.x;
        currentY = transform.position.y;

        DOTween.Init(true, false);
        if(platformDirection == PLATFORMDIRECTION.VERTICAL)
        {
            GoUp();
        }
        else
        {
            GoLeft();
        }
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
        transform.DOMove(new Vector3(maxPos + startX,currentY,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoRight);
    }

    private void GoRight()
    {
        transform.DOMove(new Vector3(minPos + startX,currentY,0), 2)
            .SetEase(Ease.Linear)
            .SetLoops(1)
            .OnComplete(GoLeft);
    }
}
