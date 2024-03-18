using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganDropoutSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private GameObject spawnedObject;
    public GameObject[] objectsToSpawn;
    public void SpawnSelectedObject(int selectedIndex)
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Проверяем, что выбран корректный индекс
        if (selectedIndex >= 0 && selectedIndex < objectsToSpawn.Length)
        {
            // Спавним выбранный объект
            spawnedObject=Instantiate(objectsToSpawn[selectedIndex], transform.position, Quaternion.identity);
        }
    }
}
