using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CheckConstructor : MonoBehaviour
{
    public Button placementButton; // Ссылка на кнопку UI Button
    public ObjectLists objectLists;
    public ColorLists colorLists;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        if(placementButton != null) {
            placementButton.onClick.AddListener(TeleportObject); // Добавляем слушатель для события "onClick" кнопки 
            textMeshPro.text = "0 из " + objectLists.mainSockets.Count.ToString("D1");
        }  
    }

    public void TeleportObject()
    {
        int result = 0;
        List<XRSocketInteractor> mainSockets = objectLists.mainSockets;
        for(int i = 0; i < mainSockets.Count; i++) 
        {
            if (mainSockets[i] != null && mainSockets[i].selectTarget is XRBaseInteractable) {
                XRBaseInteractable targetNeeded = objectLists.organs[i] as XRBaseInteractable;  // Получаем ссылку на XRBaseInteractable
                XRBaseInteractable targetCurrent = (XRBaseInteractable)mainSockets[i].selectTarget; // Получаем ссылку на XRBaseInteractable

                if(targetNeeded.name.Equals(targetCurrent.name)) {
                    colorLists.greenOrgans[i].SetActive(true);
                    result++;
                } else {
                    List<GameObject> redOrgans = colorLists.redOrgans;
                    for(int j = 0; j < redOrgans.Count; j++) {
                        if(targetCurrent.name.Equals(objectLists.organs[j].name)) {
                            redOrgans[j].transform.position = targetCurrent.transform.position; 
                            redOrgans[j].transform.rotation = targetCurrent.transform.rotation;
                            redOrgans[j].SetActive(true);
                            break;
                        }
                    }
                }
            }
        }
        textMeshPro.text = result.ToString("D1") + " из " + mainSockets.Count.ToString("D1");
    }
}