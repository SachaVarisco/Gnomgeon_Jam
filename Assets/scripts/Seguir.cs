using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] private float distancia;
    public Vector3 puntoInicial;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
      animator = GetComponent<Animator>();
      puntoInicial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {   
        distancia = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("Distancia", distancia);
        
    }

    public void Girar(){

        if (transform.position.x < player.position.x)
        {
            spriteRenderer.flipX = true;
        } else
        {
            spriteRenderer.flipX = false;
        
        }

    }

   
    
}
