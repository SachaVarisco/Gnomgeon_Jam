using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public float velocidad;
    public float detenerDistancia;
    public float retirada;

    public float tiempoDisparos;
    public float startTiempoDisparos;

    public Transform player;
    public GameObject bala;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiempoDisparos = startTiempoDisparos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,player.position) > detenerDistancia)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position, velocidad * Time.deltaTime);    
        
        } else if (Vector2.Distance(transform.position, player.position) < detenerDistancia && Vector2.Distance(transform.position, player.position) > retirada)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retirada)
        {
           transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidad * Time.deltaTime);
        }

        if (tiempoDisparos <= 0)
        {
            Instantiate(bala, transform.position, Quaternion.identity);
            tiempoDisparos = startTiempoDisparos;
        }else
        {
            tiempoDisparos -= Time.deltaTime;
        }

        
    }
}
