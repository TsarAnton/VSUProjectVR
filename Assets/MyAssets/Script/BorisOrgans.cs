using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;




public class BorisOrgans : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 3f;
    [SerializeField] public GameObject objectToSpawn; // Объект для спавна
    public Transform spawnPoint;
    private Vector3 originalScale;
    private GameObject spawnedObject;
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitSocket()
    {
        DestroyObject(spawnedObject);
        transform.localScale = originalScale;
        Debug.Log("Exit socket");
    }
    public void EnterSocket()
    {
        SpawnObject(objectToSpawn);
        Debug.Log("Entered socket");
    }
    private void SpawnObject(GameObject objectToSpawn)
    {
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, objectToSpawn.transform.rotation);
    }

private void DestroyObject(GameObject spawnedObject)
{
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }
}
