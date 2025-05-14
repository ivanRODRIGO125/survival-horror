using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject ligthObject;
    public AudioClip ligthSound;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) LightManager();
    }

    void LightManager()
    {
        ligthObject.SetActive(!ligthObject.activeSelf);
        source.PlayOneShot(ligthSound);
    }
}
