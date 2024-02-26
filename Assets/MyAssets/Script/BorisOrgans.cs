using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class BorisOrgans : MonoBehaviour
{
    [SerializeField] private Vector3 fixedScale;
    [SerializeField] private float hoverScale;
    [SerializeField] private XRSocketInteractor socketInteractor;

    public GameObject objectToSpawn;
    public Transform spawnPoint;

    private Vector3 originalScale;
    private GameObject spawnedObject;

    void Start()
    {
        originalScale = transform.localScale; 
     

        socketInteractor.onSelectEntered.AddListener(OnSelectEnter);
        socketInteractor.onSelectExited.AddListener(OnSelectExit);
    }

    private void OnSelectEnter(XRBaseInteractable interactable)
    {
        if (interactable.gameObject == gameObject)
        {
            socketInteractor.fixedScale = fixedScale;
            socketInteractor.interactableHoverScale = hoverScale;
            SpawnObject(objectToSpawn);
            Debug.Log("Entered socket");
        }
    }

    private void OnSelectExit(XRBaseInteractable interactable)
    {
        if (interactable.gameObject == gameObject)
        {
            DestroyObject(spawnedObject);
            transform.localScale = originalScale;
            Debug.Log("Exit socket");
        }
    }
    private void OnGrabEntered(XRBaseInteractable interactable)
    {
    }
    void Update()
    {
        
    }
    //public void ExitSocket()
    //{
    //    DestroyObject(spawnedObject);
    //    transform.localScale = originalScale;
    //    Debug.Log("Exit socket");
    //}
    //public void EnterSocket()
    //{
    //    SpawnObject(objectToSpawn);
    //    transform.localScale = originalScale * scaleMultiplier;
    //    Debug.Log("Entered socket");
    //}
    private void SpawnObject(GameObject objectToSpawn)
    {
        spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, objectToSpawn.transform.rotation);
    }

private void DestroyObject(GameObject spawnedObject)
{
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }
}
