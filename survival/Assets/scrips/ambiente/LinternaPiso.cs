using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinternaPiso : MonoBehaviour
{
    public GameObject LinternaReal;
   
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Linterna"))
        {
           LinternaReal.SetActive(true);
            Destroy(other.gameObject);



        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        LinternaReal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
