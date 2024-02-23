using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[System.Serializable]
public class ButtonObjectPairWithOffset
{
    public Button button; 
    public GameObject objectToSpawn; 
    public Vector3 spawnOffset;
    public Vector3 spawnRotation;
}
public class SpawnOrganWithOffset : MonoBehaviour

{
    public List<ButtonObjectPairWithOffset> buttonObjectPairs; // List of pairs button/organ to spawn
    public Transform spawnPoint; 
    
    private GameObject spawnedObject;// link to created object

    private void Start()
    {
        // add event for all buttons
        foreach (var pair in buttonObjectPairs)
        {
            pair.button.onClick.AddListener(() => SpawnObject(pair.objectToSpawn,pair.spawnOffset, pair.spawnRotation));
        }
    }

    private void SpawnObject(GameObject objectToSpawn, Vector3 spawnOffset, Vector3 spawnRotation)
    {
        // destroy previous created object
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // create new object
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position + spawnOffset, Quaternion.Euler(spawnRotation));
    }
}


