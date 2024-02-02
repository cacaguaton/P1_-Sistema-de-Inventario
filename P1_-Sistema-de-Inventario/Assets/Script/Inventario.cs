using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //El espacio esta vacio tiene un objeto
    private bool InventActivo;
    
    //Referencia al inventario
    public GameObject hud;

    //Cuantos espacios tenemos
    private int todEspa;

    //Cuantos espacios tenemos disponibles
    private int espaDispo;

    //Aqui guardamos los espacios
    private GameObject[] espacios;

    //Para asignar el espacio 
    public GameObject espacio;

    void Start()
    {
        //Cuantos espacios tienen a partir de los hijos del inventario
        todEspa = espacio.transform.childCount;

        //Creamos un game object por cada espacio
        espacios = new GameObject[todEspa];


        //Busca los espacios
        for (int i = 0; i < todEspa; i++)
        {
            //Asignamos un game object por cada espacio
            espacios[i] = espacio.transform.GetChild(i).gameObject;
            //preguntar si el espacio esta vacio
            if (espacios[i].GetComponent<Espacios>().item==null)
            {
                //Le asignamos el valor vacio en caso de cambios
                espacios[i].GetComponent<Espacios>().vacio = true;
            }
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
                hud.SetActive(true);
            }
            else
            {
                hud.SetActive(false);
            }
    }

    //Deteccion de objeto
    private void OnTriggerEnter2D(Collider2D other)
    {
        //preguntamos si es un objeto qeu podemos agarrar
        if (other.tag=="Item")
        {
            //almacenamos el objeto en un gameobject
            GameObject itemAgarrar = other.gameObject;

            //Instanciamos la clase item  para extraer los datos del item que tomamos
            Item item = itemAgarrar.GetComponent<Item>();



            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(itemAgarrar, item.getNombre(), item.getIcono(), item.getVida(), item.getDescripcion());
        }
    }
    void  Seleccionar()
    {

    }

    //Se va a encargar de a�adir el item al inventario con sus espesificaciones
    public void Agarrar(GameObject itemObj,string _nombre, Sprite _icono, int _vida, string _descripcion)
    {
        //Recorremos los espacios
        for (int i = 0;i < todEspa;i++) 
        {
            //pregunta si esta vacio
            if (espacios[i].GetComponent<Espacios>().vacio)
            {
                //Asigna que ya agarro el item
                itemObj.GetComponent<Item>().agarro = true;
                //agrega la informacion del item al espacio vacio
                espacios[i].GetComponent<Espacios>().item = itemObj;
                espacios[i].GetComponent<Espacios>().nombre = _nombre;
                espacios[i].GetComponent<Espacios>().icono = _icono;
                espacios[i].GetComponent<Espacios>().vida = _vida;
                espacios[i].GetComponent<Espacios>().descripcion = _descripcion;

                //se vuelve hijo del espacio y se guarde en el mismo
                itemObj.transform.parent = espacios[i].transform;

                //Desactivamos el item de la escena
                itemObj.SetActive(false);

                //Activa el cambio de imagen
                espacios[i].GetComponent<Espacios>().ActualizacionEspacio();

                //Decimos qeu ya no esta vacio
                espacios[i].GetComponent<Espacios>().vacio = false;

                //evitamos que llene todos los espacios y se detenga una vez encuentre uno vacio
                return;
            }

        }
    }

    void Eliminar()
    {

    }
}
