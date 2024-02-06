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
    /*
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
    }*/

    //Deteccion de objeto
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag =="Papa")
        {
            //almacenamos el objeto en un gameobject
            GameObject papaAgarrar = other.gameObject;

            //Instanciamos la clase item  para extraer los datos del item que tomamos
            Papa papa = papaAgarrar.GetComponent<Papa>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(papaAgarrar, papa.getNombre(), papa.getIcono(), papa.getVida(), papa.getDescripcion(), papa.getTipo(), papa.getRareza(), papa.getHabilidades(), papa.getEquipado());
        }
        if (other.tag =="BloqueDiamante")
        {
            //almacenamos el objeto en un gameobject
            GameObject diamanteAgarrar = other.gameObject;

            //Instanciamos la clase item  para extraer los datos del item que tomamos
            BloqueDiamante bloqueDiamante = diamanteAgarrar.GetComponent<BloqueDiamante>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(diamanteAgarrar, bloqueDiamante.getNombre(), bloqueDiamante.getIcono(), bloqueDiamante.getVida(), bloqueDiamante.getDescripcion(), bloqueDiamante.getTipo(), bloqueDiamante.getRareza(), bloqueDiamante.getHabilidades(), bloqueDiamante.getEquipado());
        }
        if (other.tag == "Espada")
        {
            //almacenamos el objeto en un gameobject
            GameObject espadaAgarrar = other.gameObject;

            //Instanciamos la clase item  para extraer los datos del item que tomamos
            Espada espada = espadaAgarrar.GetComponent<Espada>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(espadaAgarrar, espada.getNombre(), espada.getIcono(), espada.getVida(), espada.getDescripcion(), espada.getTipo(), espada.getRareza(), espada.getHabilidades(), espada.getEquipado());
        }

    }

    //Se va a encargar de añadir el item al inventario con sus espesificaciones
    public void Agarrar(GameObject itemObj,string _nombre, Sprite _icono, int _vida, string _descripcion, Tipo _tipo, Rareza _rareza, Habilidades _habilidades, bool _equipado)
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
                espacios[i].GetComponent<Espacios>().tipo = _tipo;
                espacios[i].GetComponent<Espacios>().rareza = _rareza;
                espacios[i].GetComponent<Espacios>().habilidades = _habilidades;
                espacios[i].GetComponent<Espacios>().equipado = _equipado;

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

    private void Update()
    {
        
    }
    void Eliminar()
    {

    }
}
