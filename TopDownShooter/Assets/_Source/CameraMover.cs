using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    void Update()
    {
        Vector3 newTransform = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        transform.position = newTransform;
    }
}
