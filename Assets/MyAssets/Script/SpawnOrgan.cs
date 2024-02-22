using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[System.Serializable]
public class ButtonObjectPair
{
    public Button button; // Кнопка
    public GameObject objectToSpawn; // Объект для спавна
}
public class SpawnOrgan : MonoBehaviour

{
    public List<ButtonObjectPair> buttonObjectPairs; // Список пар кнопка-объект для спавна
    public Transform spawnPoint; // Точка спавна

    private GameObject spawnedObject; // Ссылка на созданный объект

    private void Start()
    {
        // Добавляем слушатели событий для каждой кнопки
        foreach (var pair in buttonObjectPairs)
        {
            pair.button.onClick.AddListener(() => SpawnObject(pair.objectToSpawn));
        }
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        // Удаляем предыдущий объект, если он был создан
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Создаем новый объект
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}


