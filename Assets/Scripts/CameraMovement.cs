using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 2 * Time.deltaTime);
    }

}
