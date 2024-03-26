using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class EyesScale : MonoBehaviour
{
    public ObjectLists objectLists;
    public GameObject leftEye;
    public GameObject rightEye;
    private Vector3 originalScale;
    public float scaleMultiplier = 3f;

    private void Start()
    {
        for(int i = 0; i < objectLists.teleportSockets.Count; i++) {
            objectLists.teleportSockets[i].selectEntered.AddListener(OnSelectEnter);
            objectLists.teleportSockets[i].selectExited.AddListener(OnSelectExit);
        }
        originalScale = leftEye.transform.localScale; 
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        XRGrabInteractable interactable = args.interactable.GetComponent<XRGrabInteractable>();
        XRSocketInteractor socketInteractor = args.interactor.GetComponent<XRSocketInteractor>();
        if (interactable.gameObject == leftEye || interactable.gameObject == rightEye)
        {
            socketInteractor.fixedScale =  new Vector3(1, 1, 1) * scaleMultiplier;
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        XRGrabInteractable interactable = args.interactable.GetComponent<XRGrabInteractable>();
        XRSocketInteractor socketInteractor = args.interactor.GetComponent<XRSocketInteractor>();
        if (interactable.gameObject == leftEye || interactable.gameObject == rightEye)
        {
            interactable.transform.localScale = originalScale;
            socketInteractor.fixedScale =  new Vector3(1, 1, 1);
        }
    }
}