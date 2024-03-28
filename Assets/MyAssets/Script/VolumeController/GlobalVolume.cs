using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GlobalVolume : MonoBehaviour
{
    public static GlobalVolume instance;
    public float ambientVolume = 1f;
    public float effectsVolume = 0.5f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
