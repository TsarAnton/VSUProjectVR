using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections.Generic;

public class OneObjectPlacement : MonoBehaviour
{
    public Button placementButton; // Ссылка на кнопку UI Button
	public XRSocketInteractor platformSocket;
    public ObjectLists objectLists;

    private void Start()
    {
        placementButton.onClick.AddListener(PlaceObject); // Добавляем слушатель для события "onClick" кнопки   
    }

    private System.Collections.IEnumerator DelayedExecution()
    {
        yield return new WaitForSecondsRealtime(0.001f);
        platformSocket.socketActive = true;
    }

    private void PlaceObject()
    {
        bool deleted = false;
	    if (platformSocket != null && platformSocket.selectTarget is XRBaseInteractable) // Проверяем, выбран ли объект в сокете
        {
            XRBaseInteractable target = (XRBaseInteractable)platformSocket.selectTarget; // Получаем ссылку на XRBaseInteractable

	        // Удаляем объект из сокета
            platformSocket.socketActive = false;
            //target.transform.SetParent(null);
            target.transform.position = platformSocket.transform.position;
            target.transform.rotation = platformSocket.transform.rotation;
            deleted = true;
	    }

		for(int i = 0; i < objectLists.mainSockets.Count; i++) {
        	if (objectLists.mainSockets[i] != null && objectLists.mainSockets[i] != null)
        	{
	            XRBaseInteractable target1 = objectLists.organs[i] as XRBaseInteractable; // Приводим XRGrabInteractable к типу XRBaseInteractable

	            if (target1 != null)
        	    {
        		    target1.transform.position = objectLists.mainSockets[i].transform.position; // Устанавливаем позицию объекта на позицию сокета
	                target1.transform.rotation = objectLists.mainSockets[i].transform.rotation; // Устанавливаем поворот объекта в соответствии с поворотом сокета

                	//target1.transform.SetParent(objectLists.mainSockets[i].transform); // Устанавливаем родителя объекта в сокет XR Socket
				}
        	}
        }

        if(deleted) 
        {
            StartCoroutine(DelayedExecution()); 
        }
    }
}