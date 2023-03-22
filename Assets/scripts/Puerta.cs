using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    [SerializeField] private int cantEnemigos;
    [SerializeField] private int enemigosEliminados;

    private Animator animator;

    public int nivel;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cantEnemigos = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemigoEliminado(){

        enemigosEliminados += 1;

    }

    private void OnTriggerEnter2D(Collider2D player){

        if (player.CompareTag("Player") && enemigosEliminados == cantEnemigos)
        {
            SceneManager.LoadScene(nivel);
        }
    }

    
}
