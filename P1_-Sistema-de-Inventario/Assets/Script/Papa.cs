using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Heredamos de item
public class Papa : Item
{
    [SerializeField]
    private Tipo tipo;
    [SerializeField]
    private Rareza rareza;
    [SerializeField]
    private Habilidades habilidades;

    public Tipo getTipo()
    {
        return tipo;
    }

    public Rareza getRareza() 
    {
        return rareza;
    }
    public Habilidades getHabilidades()
    {
        return habilidades;
    }
    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Eliminar();
        }
    }
    public void Eliminar()
    {
        if(getEquipado())
        {
            tipo = 0;
            rareza = 0;
            habilidades = 0;
            string nombreEliminar = null;
            Sprite iconoEliminar = null;
            int vidaEliminar = 0;
            string descripcionEliminar = null;
            setItem(nombreEliminar,iconoEliminar,vidaEliminar,descripcionEliminar);
        }
    }*/

}
