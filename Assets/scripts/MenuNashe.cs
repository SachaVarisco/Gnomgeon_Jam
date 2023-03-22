using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNashe : MonoBehaviour
{
   public void Jugar(){
      SceneManager.LoadScene(1);
   }

    public void Creditos(){
      SceneManager.LoadScene(5);
   }

    public void Volver(){
       SceneManager.LoadScene(0);
    }

    public void Salir(){
     Application.Quit();
   }


}
