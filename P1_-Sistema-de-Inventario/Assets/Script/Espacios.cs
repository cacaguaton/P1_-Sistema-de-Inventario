using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Espacios : MonoBehaviour, IPointerClickHandler
{
    //Se guarda el game object
    public GameObject item;
    //Se guarda el nombre
    public string nombre;
    //Se guarda el sprite usado
    public Sprite icono;
    //Cuantos usos le quedan al item
    public int vida;
    //Se escribe ¿que es? y ¿que hace?
    public string descripcion;

    //Heredadas
    public Tipo tipo;
    public Rareza rareza;
    public Habilidades habilidades;

    //Saber si se puede almacenar
    public bool vacio;

    public Transform espacioIconoItem;


    public bool equipado;



    private void Start()
    {
        espacioIconoItem = transform.GetChild(0);
    }

    //Cambia el sprite del espacio en el UI
    public void ActualizacionEspacio()
    {
        espacioIconoItem.GetComponent<Image>().sprite = icono;
    }

    public void UsoItem()
    {
        item.GetComponent<Item>().ItemUso();
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UsoItem();
    }

    private void Update()
    {
        if (equipado)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                item = null;
                nombre = null;
                icono = null;
                vida = 0;
                descripcion = null;
                tipo = 0;
                rareza = 0;
                habilidades = 0;
                vacio = true;
                equipado = false;
                espacioIconoItem = null;
            }
        }
    }
}
