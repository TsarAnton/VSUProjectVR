using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BorisOrgans : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 3f;
    private Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitSocket()
    {
        transform.localScale = originalScale;
        Debug.Log("Exit socket");
    }
    public void EnterSocket()
    {
        transform.localScale = originalScale * scaleMultiplier; 
        Debug.Log("Entered socket");
    }
}
