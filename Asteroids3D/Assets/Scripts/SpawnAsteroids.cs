using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    BoxCollider col;
    Vector3 spawnArea;

    public GameObject asteroid;
    int spawnAmount = 0;// * level
    int asteroidsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnAmount += GameManager.instance.ReadLevel();
        col = GetComponent<BoxCollider>();
        spawnArea = new Vector3(col.bounds.size.x,0,col.bounds.size.z);
        col.enabled = false;
        Spawn();

    }
    
    void Spawn()
    {
      while (asteroidsSpawned < spawnAmount)
      {
        Vector3 pos = new Vector3(Random.Range(-spawnArea.x/2,spawnArea.x/2), 0, Random.Range(-spawnArea.z/2,spawnArea.z/2));
        if(CheckPosition(pos))
        {
          Vector3 rot = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360));
        
         Instantiate(asteroid,pos,Quaternion.Euler(rot));
         GameManager.instance.AddAsteroid();
         asteroidsSpawned++;
        }
       }
    }
    
    bool CheckPosition(Vector3 pos)
    {
      return Physics.CheckSphere(pos, 0.8f);
    }

}
