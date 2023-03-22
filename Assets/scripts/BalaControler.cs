using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaControler : MonoBehaviour
{

    public float duracion;

    void Start()
    {
        StartCoroutine(DestruirBala());
    }

    IEnumerator DestruirBala()
    {
        yield return new WaitForSeconds(duracion);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case("Enemy"):
            col.gameObject.GetComponent<EnemigoControler>().Daño();
            Destroy(gameObject);
            break;

            case("Finish"):
            col.gameObject.GetComponent<BarraDeVida>().TomarDaño();
            Destroy(gameObject);
            break;

            case("Pared"):
            Destroy(gameObject);
            break;

            default:
            break;
        }
    }
}
