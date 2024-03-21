using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class ObjectLists : MonoBehaviour
{
    public List<XRSocketInteractor> mainSockets; // Ссылка на XRSocketInteractor
    public List<XRSocketInteractor> teleportSockets;
    public List<XRGrabInteractable> organs;
    public List<InteractionLayerMask> layerMasks;

    private void Start() {}
}