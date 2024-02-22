using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[System.Serializable]
public class ButtonObjectPair
{
    public Button button; // ������
    public GameObject objectToSpawn; // ������ ��� ������
}
public class SpawnOrgan : MonoBehaviour

{
    public List<ButtonObjectPair> buttonObjectPairs; // ������ ��� ������-������ ��� ������
    public Transform spawnPoint; // ����� ������

    private GameObject spawnedObject; // ������ �� ��������� ������

    private void Start()
    {
        // ��������� ��������� ������� ��� ������ ������
        foreach (var pair in buttonObjectPairs)
        {
            pair.button.onClick.AddListener(() => SpawnObject(pair.objectToSpawn));
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        // ������� ���������� ������, ���� �� ��� ������
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // ������� ����� ������
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}


