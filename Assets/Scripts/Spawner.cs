using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitSpawn;
    [SerializeField] private GameObject bombSpawn;
    [SerializeField] private Transform[] spawnPlace;
    [SerializeField] private float minWait;
    [SerializeField] private float maxWait;
    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;
   
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    // Update is called once per frame
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform t = spawnPlace[(Random.Range(0, spawnPlace.Length))];
            GameObject go = null;
            float random = Random.Range(0, 100);
            // if(random < 30)
            // {
            //     go = bombSpawn;
            // }
            // else
            // {
            //     go = fruitSpawn[Random.Range(0, fruitSpawn.Length)];
            // }
            go = (random<25) ? bombSpawn : fruitSpawn[Random.Range(0, fruitSpawn.Length)];
            
            GameObject fruit = Instantiate(go, t.position, t.rotation);
            fruit.GetComponent<Rigidbody2D>()
                .AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            
            Destroy(fruit,5);
        }
    }
}
