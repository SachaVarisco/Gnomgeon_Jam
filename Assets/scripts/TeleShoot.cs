using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleShoot : MonoBehaviour
{
    public float tiempoDisparos;
    public float startTiempoDisparos;

    public Transform player;
    public GameObject bala;

   /////// sonido
    public AudioClip disparoDirigido; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiempoDisparos = startTiempoDisparos;
        
    }

    // Update is called once per frame
    private void DisparoT()
    {
        if (tiempoDisparos <= 0)
        {
            AudioManager.Instance.ReproducirSonido(disparoDirigido);
            Instantiate(bala, transform.position, Quaternion.identity);
            tiempoDisparos = startTiempoDisparos;
        }else
        {
            tiempoDisparos -= Time.deltaTime;
        }
    }
}
