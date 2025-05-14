using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI; // Necesario para usar Text
public class baterialinterna : MonoBehaviour
{
    public float bateria;
    public linterna linterna;
    public float consumo;
    public Text BateriaText;
    
    // Start is called before the first frame update
    void Start()
    {
        bateria = 100;
        consumo = 1;
     }

    // Update is called once per frame
    void Update()
    {
        ConsumoDeBateria();
    }

    void ConsumoDeBateria()
    {
        if (linterna.prendido == true) 
        {
            bateria -= consumo * Time.deltaTime;
            if (bateria < 0f)
                bateria = 0f;
            BateriaText.text = "bateria:" + Mathf.RoundToInt(bateria);
                   


        }


    }



}
