using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public Vector3 offset;   

    void OnTriggerEnter(Collider col)
    {
      col.gameObject.transform.position += offset;
    }

    void OnDrawGizmos()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position + offset, 0.5f);
    }
}
