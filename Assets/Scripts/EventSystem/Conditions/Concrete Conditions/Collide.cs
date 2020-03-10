using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : Condition
{
    [SerializeField]
    private Collider collider;

    [SerializeField]
    private string[] targets;

    private bool condition;

    public override bool CheckCondition()
    {
        if (condition)
            return true;

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.GetContact(collision.contactCount - 1).thisCollider == collider)
        {
            foreach (string target in targets)
            {
                if (collision.gameObject.name == target)
                {
                    condition = true;
                    return;
                }
            }
        }
    }

    private void LateUpdate()
    {
        condition = false;
    }
}
