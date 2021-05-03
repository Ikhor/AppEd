using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulator : MonoBehaviour
{
    public double peso;

    public double cinza;
    public double azul;
    public double midazolan;
    public double midazolanM5;
    public double etomidato;
    public double cetamina;  
    public double vermelho;

    public Text pesot;
    public Text altura;

    public GameObject next;
    public GameObject alerta;

    public double imc; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void calculator(){
        cinza = peso/20;
        azul = (4 * peso) / 50.0f;
        midazolan = 0.15f * peso;
        midazolanM5 = (0.15 * peso)/5.0f;
        etomidato = 0.1f * peso;
        cetamina = (1.5f * peso)/50;
        vermelho = peso/10.0f;
    }

   public void calcularIMC()
   {
      float p = float.Parse(pesot.text);
      float a = float.Parse(altura.text);
      
      imc = p /  (a * a);
      
      peso = p;

      if  (imc > 30) {
	alerta.SetActive(true);
     }
     else 
     {
	next.SetActive(true);
     }
	
   }

    
}
