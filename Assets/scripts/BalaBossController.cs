using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBossController : MonoBehaviour
{
    public float velocidad;

    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, velocidad * Time.deltaTime);

       Invoke("DestroyBala", 2f);
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovimientoJugador>().recTiro();
            DestroyBala();
        }
    }

    void DestroyBala(){
        Destroy(gameObject);
    }
}
