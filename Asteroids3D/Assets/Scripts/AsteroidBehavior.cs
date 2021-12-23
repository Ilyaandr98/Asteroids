using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class AsteroidBehavior : MonoBehaviour
{
    float speed = 0.01f;
    
    Vector3 direction;

    public enum Asteroids
    {
      BIG,
      MEDIUM,
      SMALL,
    }
    public Asteroids asteroid;
    public int score = 70;

    public GameObject asteroidToSpawn;
    public GameObject explosion;

    void Start()
    {
        direction = new Vector3(Random.Range(-360, 360), 0, Random.Range(0, 360));
        GetComponent<Rigidbody>().AddTorque(Random.Range(10, 50), 0, Random.Range(10, 50));
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += direction * speed * Time.deltaTime;  
    }

    void OnTriggerEnter(Collider col)
    {
      if (col.tag == "Bullet")
      {
        Destroy(col.gameObject);

        if(asteroid == Asteroids.BIG)
        {
          for (int i = 0; i < 2; i++)
          {
            Vector3 rot = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360));
        
            GameObject newAsteroid = Instantiate(asteroidToSpawn, transform.position,  Quaternion.Euler(rot)) as GameObject;
            AsteroidBehavior ab = newAsteroid.GetComponent<AsteroidBehavior>();
            ab.asteroid = Asteroids.MEDIUM;
            ab.score = 100;
            GameManager.instance.AddAsteroid();

          }
          Instantiate(explosion,transform.position,Quaternion.identity);
          GameManager.instance.ReduceAsteroids();
          GameManager.instance.AddScore(score);
          Destroy(gameObject);
        }

        if(asteroid == Asteroids.MEDIUM)
        {
          for (int i = 0; i < 2; i++)
          {
            Vector3 rot = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360));
        
            GameObject newAsteroid = Instantiate(asteroidToSpawn, transform.position,  Quaternion.Euler(rot)) as GameObject;
            AsteroidBehavior ab = newAsteroid.GetComponent<AsteroidBehavior>();
            ab.asteroid = Asteroids.SMALL;
            ab.score = 200;
            newAsteroid.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //появление очень маленьких комет
            GameManager.instance.AddAsteroid();
          }
          Instantiate(explosion,transform.position,Quaternion.identity);
          GameManager.instance.ReduceAsteroids();
          GameManager.instance.AddScore(score);
          Destroy(gameObject);
        }

        if(asteroid == Asteroids.SMALL)
        {
          Instantiate(explosion,transform.position,Quaternion.identity);
          GameManager.instance.ReduceAsteroids();
          GameManager.instance.AddScore(score);
          Destroy(gameObject);
        }
      }
    }
}
