using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float heightDifference;
    [SerializeField] private float time;

    void Update()
    {
        //transform.LookAt(target);
        transform.DOLookAt(target.position, time);
    }
}
