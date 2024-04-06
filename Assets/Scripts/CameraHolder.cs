using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraHolder : MonoBehaviour
{
    public Transform target;
    [SerializeField] float time;

    void Update()
    {
        transform.DOMove(target.position, time);
    }
}
