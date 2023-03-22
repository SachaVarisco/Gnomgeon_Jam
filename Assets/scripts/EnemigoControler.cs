using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemigoControler : MonoBehaviour
{
   
    ///////////////////// estadisticas
    [SerializeField] private int vida;

    /////// sonido
    public AudioClip enemigoMuerte; 

    public void Daño()
    {
        if (vida > 0)
        {
            vida -= 1;
        } else
        {
            AudioManager.Instance.ReproducirSonido(enemigoMuerte);
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>().EnemigoEliminado();
        }
    }

    
}
