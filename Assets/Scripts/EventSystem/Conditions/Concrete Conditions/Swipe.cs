using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : Condition
{
    [SerializeField]
    private Direction dir;

    [SerializeField]
    private float maxSwipeTime;

    [SerializeField]
    private float minSwipeDistance;

    private float lastTimeCheck;
    private Vector2 firstTouch;
    private bool isHold;

    public override bool CheckCondition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Input.mousePosition;
            lastTimeCheck = Time.realtimeSinceStartup;
            isHold = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isHold = false;
        }

        if (isHold)
        {
            if (Time.realtimeSinceStartup - lastTimeCheck > maxSwipeTime)
            {
                lastTimeCheck = Time.realtimeSinceStartup;
                firstTouch = Input.mousePosition;
            }

            switch (dir)
            {
                case Direction.Up:
                    if (Input.mousePosition.y - firstTouch.y > minSwipeDistance)
                    {
                        //lastTimeCheck = Time.realtimeSinceStartup;
                        firstTouch = Input.mousePosition;
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (firstTouch.y - Input.mousePosition.y > minSwipeDistance)
                    {
                        //lastTimeCheck = Time.realtimeSinceStartup;
                        firstTouch = Input.mousePosition;
                        return true;
                    }
                    break;
                case Direction.Left:
                    if (firstTouch.x - Input.mousePosition.x > minSwipeDistance)
                    {
                        //lastTimeCheck = Time.realtimeSinceStartup;
                        firstTouch = Input.mousePosition;
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (Input.mousePosition.x - firstTouch.x > minSwipeDistance)
                    {
                        //lastTimeCheck = Time.realtimeSinceStartup;
                        firstTouch = Input.mousePosition;
                        return true;
                    }
                    break;
            }
        }

        return false;
    }
}
