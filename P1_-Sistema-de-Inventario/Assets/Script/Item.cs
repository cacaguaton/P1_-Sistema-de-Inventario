using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //Utilizo [SerializeField] para cambiar los valores
    [SerializeField]
    //Se guarda el nombre
    private string nombre;
    [SerializeField]
    //Se guarda el sprite usado
    private Sprite icono;
    [SerializeField]
    //Cuantos usos le quedan al item
    private int vida;
    [SerializeField]
    //Se escribe ¿que es? y ¿que hace?
   private string descripcion;


    //obtener
    public string getNombre()
    {
        return nombre;
    }
    public Sprite getIcono()
    {
        return icono;
    }
    public int getVida() 
    {
        return vida;
    }
    public string getDescripcion()
    {
        return descripcion;
    }

    //colocar
    public void setItem(string _nombre, Sprite _icono, int _vida, string _descripcion)
    {
        nombre = _nombre;
        icono = _icono;
        vida = _vida;
        descripcion = _descripcion;
    }

    //Evitar que se vea
    [HideInInspector]
    //Saber si se agarro
    public bool agarro;

}
