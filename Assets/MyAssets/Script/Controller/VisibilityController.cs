using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    private Renderer objectRenderer; // ������ �� ��������� Renderer �������

    void Start()
    {
        // �������� ��������� Renderer �������
        objectRenderer = GetComponent<Renderer>();

        // �� ��������� ������ �������
    }

    // ������� ��� ��������� ��������� �������
    public void SetVisibility(bool isVisible)
    {
        // ������������� �������� enabled ���������� Renderer � ����������� �� ��������� isVisible
        objectRenderer.enabled = isVisible;
    }
    public void SetObjectActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}

