using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;

public class SocketScaler : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 2f; 
    [SerializeField] private Transform targetSocket; 
    private Vector3 originalScale;
    private bool enteredSocket;
    private bool exitedSocket; 

    private void Start()
    {
        originalScale = transform.localScale; // save original scale
        enteredSocket = false; // Изначально объект не находится в сокете
        exitedSocket = true;
    }

    private void Update()
    {
        if (exitedSocket == true) {
            transform.localScale = originalScale;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == targetSocket && exitedSocket)
        {
            enteredSocket = true;
            exitedSocket = false;
            transform.localScale = originalScale * scaleMultiplier; // Увеличиваем размер объекта
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == targetSocket && enteredSocket)
        {
            enteredSocket = false;
            exitedSocket = true;
            transform.localScale = originalScale; // Возвращаем объект к исходному размеру
        }
    }
}