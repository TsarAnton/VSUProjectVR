using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectPlacement : MonoBehaviour
{
    public Button placementButton; // Ссылка на кнопку UI Button
    public List<XRSocketInteractor> socketInteractors; // Ссылка на XRSocketInteractor
    public List<XRGrabInteractable> grabInteractables; // Ссылка на XRGrabInteractable

    private void Start()
    {
        placementButton.onClick.AddListener(PlaceObject); // Добавляем слушатель для события "onClick" кнопки
    }

    private void PlaceObject()
    {
	for(int i = 0; i < socketInteractors.Count; i++) {
        	if (socketInteractors[i] != null && grabInteractables[i] != null)
        	{
	            XRBaseInteractable target = grabInteractables[i] as XRBaseInteractable; // Приводим XRGrabInteractable к типу XRBaseInteractable

            	if (target != null)
            	{
        	        target.transform.position = socketInteractors[i].transform.position; // Устанавливаем позицию объекта на позицию сокета
	                target.transform.rotation = socketInteractors[i].transform.rotation; // Устанавливаем поворот объекта в соответствии с поворотом сокета

                	target.transform.SetParent(socketInteractors[i].transform); // Устанавливаем родителя объекта в сокет XR Socket
            	}
        	}
	}
    }
}