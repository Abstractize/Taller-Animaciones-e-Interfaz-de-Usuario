using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    //Components
    public Rigidbody rb;
    public Collider coll;
    //Inputs
    public float horizontalMove = 0.0f;
    public float verticalMove = 0.0f;
    private Vector3 playerInput;
    //Movement
    public float jumpSpeed = 8.0f;
    public float run = 1.0f;
    protected Vector3 movePlayer;
    public int direction = 1;
    //Objects
    public GameObject FireBall;
    public Transform RHand;
    
    //Stats
    public float SPE = 10;
    public int Lives = 3;
    public int Coins = 0;
    public float Timer = 0.0f;
    public int Score = 0;

    protected void Start()
    {

    }
    private void Awake()
    {
        
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Timer = Time.deltaTime;     
    }
    private void FixedUpdate()
    {
        MoveInput();
        SetSide();
        Jump();
        Run();
        Direction();
        rb.MovePosition(transform.position + movePlayer);
    }
    //Abilities
    protected void Jump()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity += jumpSpeed * Vector3.up;
        }
    }
    public void Run()
    {
        if (Input.GetButton("Run"))
            run = 1.5f;
        else
            run = 1.0f;
    }

    //Movement
    public void MoveInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = Vector2.ClampMagnitude(new Vector2(horizontalMove, 0.0f), 1.0f);

        movePlayer = playerInput * SPE * run;
    }
    private void SetSide()
    {
        if (horizontalMove > 0)
        {
            rb.MoveRotation(Quaternion.Euler(0.0f,90.0f, 0.0f));
        }
        else if (horizontalMove < 0)
        {
            rb.MoveRotation(Quaternion.Euler(0.0f, 90.0f + 180.0f, 0.0f));
        }
    }
    //Collisons
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Dead")) {
            Lives--;
            //RestartLevel
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    public void Fire()
    {
        GameObject instance = Instantiate(FireBall,RHand.transform.position + new Vector3(direction*2,0),Quaternion.identity);
        instance.GetComponent<Rigidbody>().velocity += 20 * Vector3.right * direction; ;
        Debug.Log(Vector3.right * 500 * direction);
        Destroy(instance, 3.0f);

    }
    //Verifications
    public bool IsGrounded()
    {
        bool hit = Physics.Raycast(coll.bounds.center, Vector3.down, coll.bounds.extents.y + 0.1f);
        return hit;
    }
    public bool IsMoving()
    {

        return (!Input.GetAxis("Vertical").Equals(0.0f) || !Input.GetAxis("Horizontal").Equals(0.0f));
    }
    private void Direction()
    {
        if (horizontalMove > 0)
            direction = 1;
        else if (horizontalMove < 0)
            direction = -1;
    }
}

