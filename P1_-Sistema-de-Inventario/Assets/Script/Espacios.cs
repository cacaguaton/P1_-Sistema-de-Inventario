using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Espacios : MonoBehaviour
{
    //Utilizo [SerializeField] para cambiar los valores desde  unity
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
    //Se guarda el tipo
    public string tipo;
    //Se guarda la rareza
    public string rareza;
    //Se guarda la habilidad
    public string habilidad;

    //Saber si se puede almacenar
    public bool vacio;

    public Transform espacioIconoItem;

    private void Start()
    {
        espacioIconoItem = transform.GetChild(0);
    }

    //Cambia el sprite del espacio en el UI
    public void ActualizacionEspacio()
    {
        espacioIconoItem.GetComponent<Image>().sprite = icono;
    }
}
