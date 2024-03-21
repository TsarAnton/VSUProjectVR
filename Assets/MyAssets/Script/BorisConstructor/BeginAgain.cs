using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BeginAgain : MonoBehaviour
{
    public Button placementButton; // Ссылка на кнопку UI Button
    public XRSocketInteractor platformSocket;
    public ObjectLists objectLists;
    public ColorLists colorLists;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        if(placementButton != null) {
            placementButton.onClick.AddListener(TeleportObject); // Добавляем слушатель для события "onClick" кнопки 
        }  
    }

    private System.Collections.IEnumerator DelayedExecution()
    {
        yield return new WaitForSecondsRealtime(0.001f);
        for(int i = 0; i < objectLists.mainSockets.Count; i++) {
            objectLists.mainSockets[i].socketActive = true;
        }
        platformSocket.socketActive = true;
    }

    public void TeleportObject()
    {
        if (platformSocket != null && platformSocket.selectTarget is XRBaseInteractable) // Проверяем, выбран ли объект в сокете
        {
            XRBaseInteractable target = (XRBaseInteractable)platformSocket.selectTarget; // Получаем ссылку на XRBaseInteractable

	        // Удаляем объект из сокета
            platformSocket.socketActive = false;
            target.transform.SetParent(null);
	    }

        List<XRSocketInteractor> mainSockets = objectLists.mainSockets;
        List<XRSocketInteractor> teleportSockets = objectLists.teleportSockets;
        for(int i = 0; i < mainSockets.Count; i++) 
        {
            XRBaseInteractable target = objectLists.organs[i] as XRBaseInteractable;  // Получаем ссылку на XRBaseInteractable
            if (mainSockets[i] != null && mainSockets[i].selectTarget is XRBaseInteractable) // Проверяем, выбран ли объект в сокете
            {
	            // Удаляем объект из сокета
                target.transform.SetParent(null);
                target.transform.position = mainSockets[i].transform.position;
                target.transform.rotation = mainSockets[i].transform.rotation;
	        }
            colorLists.redOrgans[i].SetActive(false);
            colorLists.greenOrgans[i].SetActive(false);
            mainSockets[i].socketActive = false;

            if(!(teleportSockets[i].selectTarget is XRBaseInteractable)) {
                target.transform.position = teleportSockets[i].transform.position;
                target.transform.rotation = teleportSockets[i].transform.rotation;
                target.transform.SetParent(teleportSockets[i].transform);
            }
        }
        textMeshPro.text = "0 из " + objectLists.mainSockets.Count.ToString("D1");
        StartCoroutine(DelayedExecution());
    }
}