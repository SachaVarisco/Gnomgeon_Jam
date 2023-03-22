using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DatosEntreEscenas : MonoBehaviour
{
  public static DatosEntreEscenas instance;

  public int vida;
  public int dash;
  public int gBala;
  public int vBala;
  public int cura;

  public string prefVida = "8";
  public string prefDash = "Dash";
  public string prefGBala = "gBala";
  public string prefVBala = "vBala";
  public string prefCura = "cura";

  private void Awake()
  {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
         loadData();
      } else
      {
        if (instance != this)
        {
            Destroy(gameObject);
        }
      }
  }

   private void OnDestroy()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(prefVida, vida);
        PlayerPrefs.SetInt(prefDash, dash);
        PlayerPrefs.SetInt(prefVBala, vBala);
        PlayerPrefs.SetInt(prefCura, cura);
        
    }

    private void loadData()
    {
        vida = PlayerPrefs.GetInt(prefVida, 8);
        dash = PlayerPrefs.GetInt(prefDash,0);
        cura = PlayerPrefs.GetInt(prefCura,0);
        vBala = PlayerPrefs.GetInt(prefVBala,0);
    }
}
