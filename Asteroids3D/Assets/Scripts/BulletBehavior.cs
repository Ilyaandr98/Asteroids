using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 20f;   

    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
