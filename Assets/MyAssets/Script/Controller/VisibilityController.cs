using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    private Renderer objectRenderer; // Ссылка на компонент Renderer объекта

    void Start()
    {
        // Получаем компонент Renderer объекта
        objectRenderer = GetComponent<Renderer>();

        // По умолчанию объект видимый
    }

    // Функция для установки видимости объекта
    public void SetVisibility(bool isVisible)
    {
        // Устанавливаем свойство enabled компонента Renderer в зависимости от параметра isVisible
        objectRenderer.enabled = isVisible;
    }
    public void SetObjectActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}

