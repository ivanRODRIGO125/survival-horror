using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaabrir : MonoBehaviour
{
    private GameObject DetectaColision;
    public GameObject LuzSala;
    public GameObject LuzPasillo;
    public float contador = 3f; // Tiempo inicial en segundos
    public bool ContadorBool = false;
    public float RestarContador = 1f; // Velocidad de cuenta regresiva (1 = 1 seg/seg)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerPuerta"))
        {
            DetectaColision = other.gameObject;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == DetectaColision)
        {
            DetectaColision = null;
        }
    }

    private void Update()
    {
        // Presionar Q cuando está en el trigger
        if (DetectaColision != null && Input.GetKeyDown(KeyCode.Q))
        {
            ContadorBool = true;
            if (DetectaColision != null)
            {
                Destroy(DetectaColision);
                DetectaColision = null;
            }

        }

        // Lógica de la cuenta regresiva
        if (ContadorBool)
        {
            contador -= RestarContador * Time.deltaTime;

            if (contador <= 0)
            {
                contador = 0;
               
                if (LuzSala != null) Destroy(LuzSala);
                if (LuzPasillo != null) Destroy(LuzPasillo);

                

                ContadorBool = false; // Evita que siga ejecutándose
            }
        }
    }
}

