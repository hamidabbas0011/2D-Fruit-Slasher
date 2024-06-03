using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fruits : MonoBehaviour
{
    [SerializeField] private GameObject slicedFruitPrefab;

    public void Update()
    {
        
    }


    public void CreateSlicedFruits()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rbsOnSlice = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rbs in rbsOnSlice)
        {
            rbs.transform.rotation = Random.rotation;
            rbs.AddExplosionForce(Random.Range(10,300),transform.position,5f);
        }
        FindObjectOfType<GameManager>().ScoreSystem();
        Destroy(gameObject);
        Destroy(inst.gameObject,3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Blade b = other.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        
        CreateSlicedFruits();
    }
}
