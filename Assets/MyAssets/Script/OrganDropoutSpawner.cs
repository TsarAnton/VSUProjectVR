using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class OrganToSpawn
{
    public GameObject objectToSpawn;
    public Vector3 spawnOffset;
    public Vector3 spawnRotation;
}
public class OrganDropoutSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private GameObject spawnedObject;
    public List<OrganToSpawn> organsToSpawn;
 
    public void SpawnSelectedObject(int selectedIndex)
    {
        SpawnObject(selectedIndex, organsToSpawn[selectedIndex].spawnOffset, organsToSpawn[selectedIndex].spawnRotation);
    }
    private void SpawnObject(int selectedIndex, Vector3 spawnOffset, Vector3 spawnRotation)
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        Debug.Log(organsToSpawn.Count);
        // ���������, ��� ������ ���������� ������
        if (selectedIndex >= 0 && selectedIndex < organsToSpawn.Count)
        {
            // ������� ��������� ������
            spawnedObject = Instantiate(organsToSpawn[selectedIndex].objectToSpawn, spawnPoint.position + spawnOffset, Quaternion.Euler(spawnRotation));
        }
    }
    public void RotateObject(float value)
    {
        Vector3 currentRotation = spawnedObject.transform.rotation.eulerAngles;
        spawnedObject.transform.rotation = Quaternion.Euler(currentRotation.x, value * 360, currentRotation.z);
    }
}
