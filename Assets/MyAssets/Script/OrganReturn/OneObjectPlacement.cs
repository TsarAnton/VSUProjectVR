using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections.Generic;

public class OneObjectPlacement : MonoBehaviour
{
    public Button placementButton; // Ссылка на кнопку UI Button
	public XRSocketInteractor platformSocket;
    public List<XRSocketInteractor> socketInteractors; // Ссылка на XRSocketInteractor
    public List<XRGrabInteractable> grabInteractables; // Ссылка на XRGrabInteractable

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
            target.transform.SetParent(null);
            target.transform.position = platformSocket.transform.position;
            target.transform.rotation = platformSocket.transform.rotation;
            deleted = true;
	    }

		for(int i = 0; i < socketInteractors.Count; i++) {
        	if (socketInteractors[i] != null && grabInteractables[i] != null)
        	{
	            XRBaseInteractable target1 = grabInteractables[i] as XRBaseInteractable; // Приводим XRGrabInteractable к типу XRBaseInteractable

	            if (target1 != null)
        	    {
        		    target1.transform.position = socketInteractors[i].transform.position; // Устанавливаем позицию объекта на позицию сокета
	                target1.transform.rotation = socketInteractors[i].transform.rotation; // Устанавливаем поворот объекта в соответствии с поворотом сокета

                	target1.transform.SetParent(socketInteractors[i].transform); // Устанавливаем родителя объекта в сокет XR Socket
				}
        	}
        }

        if(deleted) 
        {
            StartCoroutine(DelayedExecution()); 
        }
    }
}