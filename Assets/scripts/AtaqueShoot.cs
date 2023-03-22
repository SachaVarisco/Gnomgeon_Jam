using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueShoot : MonoBehaviour
{
    public float tiempoDisparos;
    public float startTiempoDisparos;

    public Transform player;
    public GameObject bala;
  
    /////// sonido
    public AudioClip disparoJefe; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiempoDisparos = startTiempoDisparos;
    }

    // Update is called once per frame
    private void Disparo(){
    
        if (tiempoDisparos <= 0)
        {
            AudioManager.Instance.ReproducirSonido(disparoJefe);
            Instantiate(bala, transform.position, Quaternion.identity);
            tiempoDisparos = startTiempoDisparos;
        }else
        {
            tiempoDisparos -= Time.deltaTime;
        }
    }
}
