using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class PlayerBehavior : MonoBehaviour
{
    //movement
    float maxSpeed = 10f;
    float rotatationSpeed = 150f;
    Rigidbody rb;

    //BULLET
    public GameObject bullet;
    public Transform spawnPoint;

    //POSITION
    Vector3 initPosition;
    public GameObject explosion;

    bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
    }

    void FixedUpdate()
    {
        //if(!isDead)
        //{
            if (Input.GetKey(KeyCode.A))
            {
              transform.RotateAround(transform.position, -Vector3.up, rotatationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
              transform.RotateAround(transform.position, Vector3.up, rotatationSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
              rb.AddForce(transform.forward * maxSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
              rb.AddForce(-transform.forward * maxSpeed);
            }
        //}
    }

    void Update ()
    {
       //if (!isDead)
       //{
          //shoot
          if (Input.GetKeyDown(KeyCode.Space))
          {
            if (bullet != null)
            {
             Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            }
          }
       //}
    }

    void OnTriggerEnter(Collider col)
    {
      if(col.tag == "Asteroid")
      {
         //сброс
         //потерять жизнь
         isDead = true;
         Instantiate(explosion,transform.position,Quaternion.identity);
         GameManager.instance.LoseLife();
         StartCoroutine(Reset());
      }
    }

    IEnumerator Reset()
    {
       rb.velocity = Vector3.zero;
       GetComponent<MeshRenderer>().enabled = false;
       GetComponent<Collider>().enabled = false;
       transform.position = initPosition;
       yield return new WaitForSeconds(3f);
       GetComponent<MeshRenderer>().enabled = true;
       GetComponent<Collider>().enabled = true;
       isDead = false;
    }
}
