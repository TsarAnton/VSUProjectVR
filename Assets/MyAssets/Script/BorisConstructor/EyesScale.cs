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
        //Debug.Log(originalScale);
        //Debug.Log("Started");
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log("OnSelectEntered");
        XRGrabInteractable interactable = args.interactable.GetComponent<XRGrabInteractable>();
        XRSocketInteractor socketInteractor = args.interactor.GetComponent<XRSocketInteractor>();
        if (interactable.gameObject == leftEye || interactable.gameObject == rightEye)
        {
            //Debug.Log("It's eye");
            interactable.transform.localScale = originalScale * scaleMultiplier;
            socketInteractor.fixedScale =  new Vector3(1, 1, 1) * scaleMultiplier;
            //Debug.Log(interactable.transform.localScale);
            //Debug.Log(socketInteractor.fixedScale);
        }
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        //Debug.Log("OnSelectExited");
        XRGrabInteractable interactable = args.interactable.GetComponent<XRGrabInteractable>();
        if (interactable.gameObject == leftEye || interactable.gameObject == rightEye)
        {
            //Debug.Log("It's eye");
            interactable.transform.localScale = originalScale;
            //Debug.Log(interactable.transform.localScale);
        }
    }
}