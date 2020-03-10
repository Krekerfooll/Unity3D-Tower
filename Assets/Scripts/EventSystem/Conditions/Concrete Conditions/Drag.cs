using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : Condition
{
    [SerializeField]
    private Direction dir;

    private Vector2 firstTouch;
    private bool isHold;

    public override bool CheckCondition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Input.mousePosition;
            isHold = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isHold = false;
        }

        if (isHold)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (firstTouch.y < Input.mousePosition.y)
                        return true;
                    break;
                case Direction.Down:
                    if (firstTouch.y > Input.mousePosition.y)
                        return true;
                    break;
                case Direction.Left:
                    if (firstTouch.x > Input.mousePosition.x)
                        return true;
                    break;
                case Direction.Right:
                    if (firstTouch.x < Input.mousePosition.x)
                        return true;
                    break;
            }
        }

        return false;
    }
}
