using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linterna : MonoBehaviour
{
    public GameObject luz;
    public AudioClip SonidoLinterna;
    private AudioSource source;
    public bool prendido;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ActivarBooleano();

        if (Input.GetKeyDown(KeyCode.F)) 
        { 
            
            
            LinternaManager();
           
          }






        }

    void ActivarBooleano()
    {
        if (luz.activeInHierarchy == true)
        {
            prendido = true;
            
        }
        else 
        {
            prendido = false; 
        }

    }
    void LinternaManager() 
    { if (luz) {
        
        luz.SetActive(!luz.activeSelf);
      source.PlayOneShot(SonidoLinterna);    //PlayOneShot reproduce el sonido una unica vez
            prendido = false;
    }

      }
}



