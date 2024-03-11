using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectPlacementController : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public GameObject objectToPlace;
    private bool isPlaced = false;

    private void Start()
    {
        // Получаем ссылку на компонент XRSocketInteractor
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    public void PlaceObjectInSocket()
    {
        if (!isPlaced)
        {
            // Создаем новый экземпляр объекта
            GameObject instantiatedObject = Instantiate(objectToPlace, transform.position, transform.rotation);
            
            // Помещаем объект в XR-сокет
            socketInteractor.selectTarget = instantiatedObject.GetComponent<XRGrabInteractable>();

            isPlaced = true;
        }
        else
        {
            // Удаляем объект из XR-сокета
            socketInteractor.selectTarget = null;
            Destroy(socketInteractor.selectTarget.gameObject);

            isPlaced = false;
        }
    }
}