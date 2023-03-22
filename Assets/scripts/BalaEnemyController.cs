using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemyController : MonoBehaviour
{
    public float velocidad;
    private int speed;

    private Transform player;
    private Vector2 target;

    void Awake()
    {
       if (speed != 0)
       {
          velocidad += 4;
       }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);     
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, velocidad * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y )
        {
            DestroyBala();
        }

    }

    void OnTriggerEnter2D(Collider2D other){

         switch (other.gameObject.tag)
        {
            case("Player"):
            other.gameObject.GetComponent<MovimientoJugador>().recTiro();
            DestroyBala();
            break;

            case("Pared"):
            DestroyBala();
            break;

            default:
            break;
        }

    }

    void DestroyBala(){
        Destroy(gameObject);
    }

    private void LoadData()
    {
        speed = DatosEntreEscenas.instance.vBala;
    }
}
