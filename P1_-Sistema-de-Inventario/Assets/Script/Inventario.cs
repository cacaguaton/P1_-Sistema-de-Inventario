using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //El espacio esta vacio tiene un objeto
    private bool InventActivo;
    
    //Referencia al inventario
    public GameObject Hud;

    //Cuantos espacios tenemos
    private int TodEspa;

    //Cuantos espacios tenemos disponibles
    private int EspaDispo;

    //Aqui guardamos los espacios
    private GameObject[] Espacios;

    //Para asignar el espacio
    public GameObject Espacio;

    void Start()
    {
        //Cuantos espacios tienen a partir de los hijos del inventario
        TodEspa = Espacio.transform.childCount;

        //Creamos un game object por cada espacio
        Espacios = new GameObject[TodEspa];


        //Busca los espacios
        for (int i = 0; i < TodEspa; i++)
        {
            //Asignamos un game object por cada espacio
            Espacios[i] = Espacio.transform.GetChild(i).gameObject;
        }

    }
    private void Update()
    {
        //pregunta si esta activo
            if (Input.GetKeyDown(KeyCode.I))
            {
                InventActivo = !InventActivo;
            }

            // Se activa o desactiva el inventario
            if (InventActivo)
            {
                Hud.SetActive(true);
            }
            else
            {
                Hud.SetActive(false);
            }
    }

    void  Seleccionar()
    {

    }

    void Agarrar()
    {
        
    }

    void Eliminar()
    {

    }
}
