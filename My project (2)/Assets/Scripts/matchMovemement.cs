using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchMovemement : MonoBehaviour
{
    public GameObject objectfollowing;
    public GameObject objectwantingtoMove;
    public Vector3 offset;

    void Start()
    {
    }
    void Update()
    {
        objectwantingtoMove.transform.position = objectfollowing.transform.position + offset;
    }
}
