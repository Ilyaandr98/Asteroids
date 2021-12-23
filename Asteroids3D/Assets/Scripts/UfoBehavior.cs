using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class UfoBehavior : MonoBehaviour
{
    float speed = 0.005f;
    int health = 3;

    public GameObject bullet;
    public Transform spawnPoint;
    float shootDelay = 1.5f;

    public GameObject explosion;
    GameObject player;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("SHIP");

        direction = new Vector3(Random.Range(-360,360), 0, Random.Range(-360,360));

        InvokeRepeating("Shoot", shootDelay, shootDelay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void Shoot()
    {
       spawnPoint.LookAt(player.transform);
       Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    }

    void OnTriggerEnter(Collider col)
    {
      if(col.tag == "Asteroid")
      {
        //взрыв
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
      }
      else if (col.tag == "Bullet")
      {
        //взрыв
        Instantiate(explosion,transform.position,Quaternion.identity);
        TakeDamage();
        Destroy(col.gameObject);
      }
    }

    void TakeDamage()
    {
      health--;
      if(health<=0)
      {
        //взрыв
        Instantiate(explosion,transform.position,Quaternion.identity);
        GameManager.instance.AddScore(1000);
        Destroy(gameObject);
      }
    }
}
