using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoJugador : MonoBehaviour
{   
    private Rigidbody2D playerRb;
    
/////////////////// personaje
    [SerializeField] private float speed = 3f;
    private Vector2 moveInput;
    private float moveX;
    private float moveY;
    private float disparoX;
    private float disparoY;
   
//////////////////  disparos
    public GameObject balaPrefab;
    public float velocidadBala;
    private float ultimoDisparo;
    public float delayDisparo;
    public float daño;

////////////////// Animación
    private Animator animator;


////////////////// Vidas
    public Image Corazon;
    public int CantCorazon;
  //  public int CorMax = 8;
  //  public int CorFalta;
    public RectTransform PosPrimerCorazon;
    public Canvas MyCanvas;
    public float OffSet;

////////////////PowerUps
    public bool dash = false;
    public bool cura = false;
    public bool vBala = false;

    public int curaInt = 0;
    public int dashInt = 0;
    public int vBalaInt = 0;

//////////#Dash
    private bool canDash = true; 
    private bool isDash;
    private float dashPower = 40f;
    private float dashTime = 0.2f;
    private float dashCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    private void Start(){
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        
      ///////////vidas
        Transform PosCorazon = PosPrimerCorazon;
        for (int i = 0; i < CantCorazon; i++)
        {
            Image NewCorazon = Instantiate(Corazon, PosCorazon.position, Quaternion.identity);
            NewCorazon.transform.parent = MyCanvas.transform;
            PosCorazon.position = new Vector2(PosCorazon.position.x + OffSet, PosCorazon.position.y);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDash){
            return;
        }

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);

        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
        

        disparoX = Input.GetAxisRaw("DisparoHorizontal");
        disparoY = Input.GetAxisRaw("DisparoVertical");

       

        

        if ((disparoX !=0 || disparoY != 0) && Time.time > ultimoDisparo + delayDisparo)
        {
            Disparo(disparoX, disparoY);
            ultimoDisparo = Time.time;
        }
        
        ////Muerte
        if (CantCorazon <= 0)
        {
          animator.SetTrigger("Muerte");
          Destroy(Corazon);
          StartCoroutine(Escena());
        }

        ////////PowerUps

        if (dash == true && Input.GetButtonDown("Jump"))
        {
           StartCoroutine(Dash());
            
        }

        if (vBala == true)
        {
            delayDisparo = 0.2f;
        }

        if (curaInt != 0)
        {
            cura = true;
        }

        if (vBalaInt != 0)
        {
            vBala = true;
        }

        if (dashInt != 0)
        {
            dash = true;
        }

    }

    private void FixedUpdate()
    {
        if (isDash){
            return;
        }
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }

   private void Disparo(float x, float y)
   {
        GameObject bala = Instantiate(balaPrefab, transform.position, transform.rotation) as GameObject;
        bala.AddComponent<Rigidbody2D>().gravityScale = 0;
        bala.GetComponent<Rigidbody2D>().velocity = new Vector2(
        (x<0) ? Mathf.Floor(x) * velocidadBala : Mathf.Ceil(x) * velocidadBala,
        (y<0) ? Mathf.Floor(y) * velocidadBala : Mathf.Ceil(y) * velocidadBala
        );
   }

 ///////////Recibir daño
    private void OnCollisionEnter2D(Collision2D collision){

    
        switch (collision.gameObject.tag)
        {
            case("Enemy"):
            Destroy(MyCanvas.transform.GetChild(CantCorazon + 1).gameObject);
            CantCorazon -= 1;
            break;
             
            case("Bala"):
            Destroy(MyCanvas.transform.GetChild(CantCorazon + 1).gameObject);
            CantCorazon -= 1;
            break;

            case("Dash"):
            dash = true;
            Destroy(collision.gameObject);
            break;

            case("Cura"):
            cura = true;
            Destroy(collision.gameObject);
            break;

            case("VelBala"):
            vBala = true;
            Destroy(collision.gameObject);
            break;

            default:
            break;
        }
    }
    
    public void recTiro(){
        Destroy(MyCanvas.transform.GetChild(CantCorazon + 1).gameObject);
        CantCorazon -= 1;
    }

////Dash
    private IEnumerator Dash(){
        canDash = false;
        isDash = true;
        playerRb.velocity = moveInput * dashPower;
        tr.emitting = true; 
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

///// datos
private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        DatosEntreEscenas.instance.vida = CantCorazon;
        DatosEntreEscenas.instance.dash = dashInt;
        DatosEntreEscenas.instance.vBala = vBalaInt;
        DatosEntreEscenas.instance.cura = curaInt;
    }

    private void loadData()
    {
        CantCorazon = DatosEntreEscenas.instance.vida;
        dashInt = DatosEntreEscenas.instance.dash;
        curaInt = DatosEntreEscenas.instance.cura;
        vBalaInt = DatosEntreEscenas.instance.vBala;
    }

private IEnumerator Escena()
{
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene(0);
}


}
