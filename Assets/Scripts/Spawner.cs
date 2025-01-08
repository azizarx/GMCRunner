using System;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        GameObject newPlane = Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation);
        newPlane.gameObject.name = "NewPlane";
    }
}
