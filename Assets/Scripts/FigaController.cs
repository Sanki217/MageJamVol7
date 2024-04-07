using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class FigaController : MonoBehaviour
{
    public int PlayerNumber;
    [SerializeField] private string horizontalMovement;
    [SerializeField] private string verticalMovement;
    [SerializeField] private float speed;
    private Rigidbody rb;
    public Transform RetryPoint;

    private float rightSpeed;
    private float forwardSpeed;
    public bool CanMove = true;
    public bool GameEnded = false;
    [SerializeField] private float topSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        transform.position=RetryPoint.position;
    }


    private void Update()
    {
        rightSpeed = Input.GetAxis(horizontalMovement);
        forwardSpeed = Input.GetAxis(verticalMovement);

        if (CanMove && !GameEnded)
        {
            if (Input.GetButton("Fire" + PlayerNumber.ToString()))
            {
                Retry();
            }
        }
        
    }

    void FixedUpdate()
    {
        if (CanMove&&!GameEnded)
        {
            rb.AddForce(Vector3.right * -speed * rightSpeed);
            rb.AddForce(Vector3.forward * -speed * forwardSpeed);


        }
        if(rb.velocity.magnitude > topSpeed)
        {
            rb.velocity=Vector3.ClampMagnitude(rb.velocity, topSpeed);
        }
        
    }

    public void Retry()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        GetComponent<SphereCollider>().enabled = false;
        transform.DOMove(RetryPoint.position, 1f);
        CanMove = false;
        StartCoroutine(ReturnCoroutine());
    }
    IEnumerator ReturnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        GetComponent<SphereCollider>().enabled = true;
        CanMove = true;
    }
}
