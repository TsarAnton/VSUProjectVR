using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TPShowRoom() 
    {
    SceneManager.LoadScene("Showroom");
    }

    public void TPMain() 
    {
    SceneManager.LoadScene("Main_Scene");
    }

    public void TPCinema() 
    {
    SceneManager.LoadScene("Cinema_Scene");
    }

}
