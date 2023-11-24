using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject particuleEffect;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 180, 0), 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(particuleEffect, transform.position, Quaternion.identity);
            transform.DOScale(new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, transform.localScale.z * 1.5f), .3f).OnComplete(() =>
            {
                transform.DOScale(new Vector3(0, 0, 0), .5f).OnComplete(() =>
                {
                    //spawn particule effect
                    Destroy(gameObject);
                });
            });
        }
    }
}
