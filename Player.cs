using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PlayerObj;
    public float speed;
    public Grid currentGrid;

    Rigidbody rb;
    Animator animator;


    private void Start()
    {
        PlayerObj = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z).normalized;

        Vector3 velocity = move * speed;

        bool walkAble = move.magnitude > 0f ? true : false;

        animator.SetBool("Walk", walkAble);

        rb.velocity = velocity;

        if(move.magnitude > 0f)
        {
            Quaternion trRotate = Quaternion.LookRotation(move);
            PlayerObj.transform.rotation = Quaternion.Slerp(PlayerObj.transform.rotation, trRotate, 10 * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grid"))
        {
            Grid grids = collision.gameObject.GetComponent<Grid>();
            currentGrid = grids;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grid"))
        {
            Grid grids = collision.gameObject.GetComponent<Grid>();
            if(grids != null)
                currentGrid = null;
        }
    }
}
