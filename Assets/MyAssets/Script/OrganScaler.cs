using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrganScaler : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socketInteractor; // XR Socket Interactor, �� ������� ��������� ������
    [SerializeField] private float scaleMultiplier = 2f; // ��������� ���������������
    [SerializeField] private Transform targetSocket;
    private Vector3 originalScale; // �������� ������ �������

    private void Start()
    {
        originalScale = transform.localScale; // ��������� �������� ������ �������
        socketInteractor.onSelectEntered.AddListener(OnSelectEnter); // ������������� �� ������� ����� � �����
        socketInteractor.onSelectExited.AddListener(OnSelectExit); // ������������� �� ������� ������ �� ������
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == targetSocket)
        {
            transform.localScale = originalScale * scaleMultiplier; // Увеличиваем размер объекта
            Debug.Log("Trigger enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == targetSocket)
        {
            transform.localScale = originalScale; // Возвращаем объект к исходному размеру
            Debug.Log("Trigger exit");
        }
    }

    private void OnSelectEnter(XRBaseInteractable interactable)
    {
        // ���������, ��� ������ � ������ � ������������ ���
        if (interactable.gameObject == gameObject)
        {
            transform.localScale = originalScale * scaleMultiplier; // ������������ ������
            Debug.Log("Entered socket");
        }
    }

    private void OnSelectExit(XRBaseInteractable interactable)
    {
        // ���������, ��� ������ ����� �� ������ � ���������� ��� � ��������� �������
        if (interactable.gameObject == gameObject)
        {
           // transform.localScale = originalScale; // ���������� ������ � ��������� �������
            Debug.Log("Exit socket");
        }
    }
}