using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticuleEffect : MonoBehaviour
{
    [SerializeField] float maxTime;
    void Update()
    {
        if (maxTime > 0)
        {
            maxTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
