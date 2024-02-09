using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; //De aqui saque imagen

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

    //Cambia el sprite del espacio en el UI
    public Transform espacioIconoItem;

    public bool equipado;



    private void Start()
    {
        //Le asigna el transform del primer hijo
        espacioIconoItem = transform.GetChild(0);

    }

    //Cambia el sprite del espacio en el UI
    public void ActualizacionEspacio()
    {
        //Asigna al espacio de la ui el icono del item
        espacioIconoItem.GetComponent<Image>().sprite = icono;
    }

    
    public void UsoItem()
    {
        //llamamos el metodo ItemUso del script Item
        item.GetComponent<Item>().ItemUso();
    }

    //Cuando detecte el click  se va activar, tambien detecta posicion
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UsoItem();
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DatosEnviados();
        }
        
        if (equipado)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Destroy(item);
            
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

public void RecibirDatosDesdeHijo(GameObject _itemObj, string _nombre, Sprite _icono, int _vida, string _descripcion, Tipo _tipo, Rareza _rareza, Habilidades _habilidades, bool _equipado)
    {
        // Hacer algo con los datos recibidos del hijo
        item = _itemObj;
        nombre = _nombre;
        icono = _icono;
        vida = _vida;
        descripcion = _descripcion;
        tipo = _tipo;
        rareza = _rareza;
        habilidades = _habilidades;
        equipado = _equipado;

    }

    public void DatosEnviados()
    {
        item.GetComponent<Item>().EnviarDatosAlPadre();
    }*/
}
