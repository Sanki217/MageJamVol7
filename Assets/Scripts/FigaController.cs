using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FigaController : MonoBehaviour
{
    public int PlayerNumber;
    [SerializeField] private string horizontalMovement;
    [SerializeField] private string verticalMovement;
    [SerializeField] private float speed;
    private Rigidbody rb;

    private float rightSpeed;
    private float forwardSpeed;
    public bool CanMove = true;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }


    private void Update()
    {
        rightSpeed = Input.GetAxis(horizontalMovement);
        forwardSpeed = Input.GetAxis(verticalMovement);
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            rb.AddForce(Vector3.right * -speed * rightSpeed);
            rb.AddForce(Vector3.forward * -speed * forwardSpeed);
        }

        
    }
}
