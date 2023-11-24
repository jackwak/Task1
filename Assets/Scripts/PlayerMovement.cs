using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float zSpeed;
    [SerializeField] float xSpeed;

    bool onFinish;
    Vector3 _input;
    bool canMove;

    private void Start()
    {
        canMove = true;
        onFinish = false;
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish" && onFinish == false)
        {
            onFinish = true;
            canMove = false;
            transform.DOJump(transform.position, 3f, 1, 1f, false).OnComplete(() =>
            {
                transform.DOPunchScale(new Vector3(2, 2, 2), 1f, 1, 1);
            });
        }
    }

    void Move()
    {
        if (!canMove) return;
        _input.x = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(_input.x * xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime));

        if (transform.position.x >= 5)
        {
            transform.position = new Vector3(5, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -5)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.z);
        }
    }
}
