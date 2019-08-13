using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hit = collision.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);
            //Down
            if (Mathf.Approximately(angle, 0))
            {
                Action(collision.gameObject.GetComponent<MovementController>());
            }
        }
    }
    protected abstract void Action(MovementController player);
}
