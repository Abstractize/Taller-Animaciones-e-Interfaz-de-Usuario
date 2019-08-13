using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    Rigidbody rb;
    Collider coll;

    int direction = 1;
    //Stats
    public float SPE;
    private void Awake()
    {
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.right * SPE * direction);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Detect side of collision
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hit = collision.contacts[0].normal;
            float angle = Vector3.Angle(hit, Vector3.up);
            //Up
            if (Mathf.Approximately(angle, 180))
            {
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<MovementController>().Lives--;
                //RestartLevel
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        ChangeDirection();
    }
    private void ChangeDirection()
    {
        if (direction == -1)
            direction = 1;
        else if (direction == 1)
            direction = -1;
        else
            direction = 1;
    }
}
