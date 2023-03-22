using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BarraDeVida : MonoBehaviour
{

    public Rigidbody2D rb2D;

  ///////Relacionadas al jugador  
    public Transform player;
    [SerializeField] private float distancia;
    public Vector3 puntoInicial;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


 /////////Vida   
   [SerializeField] private float vida;
   [SerializeField] private float maximoVida;
   [SerializeField] private BarraLife barraVida;


    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        vida = maximoVida;
        barraVida.InicializarBarraDeVida(vida);
    }

    void Update(){
        distancia = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("Distancia", distancia);

       
    }
    
    public void TomarDaño(){
        
        vida -= 1;
        barraVida.CambiarVidaActual(vida);

        if(vida <= 0){
            animator.SetTrigger("Muerte");
            StartCoroutine(Escena());
        }
    
    }
    private IEnumerator Escena()
    {
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene(3);
    }

    }

    
