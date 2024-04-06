using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FigaController : MonoBehaviour
{
    [SerializeField] private string horizontalMovement;
    [SerializeField] private string verticalMovement;
    [SerializeField] private string jumpMovement;
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }


    private void Update()
    {
        rb.AddForce(Vector3.right * -speed * Input.GetAxis(horizontalMovement));
        rb.AddForce(Vector3.forward * -speed * Input.GetAxis(verticalMovement));

    }

    void FixedUpdate()
    {
        
        


    }
}
