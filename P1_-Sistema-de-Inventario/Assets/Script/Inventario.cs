using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    /*
    private bool InventActivo;*/

    //Referencia al inventario
    public GameObject hud;

    //Cuantos espacios tenemos
    private int todEspa;

    //Cuantos espacios tenemos disponibles
    private int espaDispo;

    //Aqui guardamos los espacios
    private GameObject[] espacios;
   // public GameObject[] getEspacios()
     //{ return espacios; }

    //Para asignar el espacios dentro de el gameObject espacio en el canva 
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
            if (espacios[i].GetComponent<Espacios>().item == null)
            {
                //Le asignamos el valor vacio en caso de cambios
                espacios[i].GetComponent<Espacios>().vacio = true;
            }
        }


        //  if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    Eliminar();
        //  }
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

        if (other.tag == "Papa")
        {
            //almacenamos el objeto en un gameobject
            GameObject papaAgarrar = other.gameObject;

            //Instanciamos la clase Papa  para extraer los datos del item que tomamos
            Papa papa = papaAgarrar.GetComponent<Papa>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(papaAgarrar, papa.getNombre(), papa.getIcono(), papa.getVida(), papa.getDescripcion(), papa.getTipo(), papa.getRareza(), papa.getHabilidades(), papa.getEquipado());
            //ItemAElimPapa(papaAgarrar);
        }
        if (other.tag == "BloqueDiamante")
        {
            //almacenamos el objeto en un gameobject
            GameObject diamanteAgarrar = other.gameObject;

            //Instanciamos la clase BloqueDiamante  para extraer los datos del item que tomamos
            BloqueDiamante bloqueDiamante = diamanteAgarrar.GetComponent<BloqueDiamante>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(diamanteAgarrar, bloqueDiamante.getNombre(), bloqueDiamante.getIcono(), bloqueDiamante.getVida(), bloqueDiamante.getDescripcion(), bloqueDiamante.getTipo(), bloqueDiamante.getRareza(), bloqueDiamante.getHabilidades(), bloqueDiamante.getEquipado());
            //ItemAElimBloque(diamanteAgarrar);
        }
        if (other.tag == "Espada")
        {
            //almacenamos el objeto en un gameobject
            GameObject espadaAgarrar = other.gameObject;

            //Instanciamos la clase Espada  para extraer los datos del item que tomamos
            Espada espada = espadaAgarrar.GetComponent<Espada>();

            //Se activa el metodo agarrar y le ponemos los parametros necesarios
            Agarrar(espadaAgarrar, espada.getNombre(), espada.getIcono(), espada.getVida(), espada.getDescripcion(), espada.getTipo(), espada.getRareza(), espada.getHabilidades(), espada.getEquipado());
            //ItemAElimEspada(espadaAgarrar);
        }

    }

    //Se va a encargar de añadir el item al inventario con sus espesificaciones
    public void Agarrar(GameObject itemObj, string _nombre, Sprite _icono, int _vida, string _descripcion, Tipo _tipo, Rareza _rareza, Habilidades _habilidades, bool _equipado)
    {
        //Recorremos los espacios
        for (int i = 0; i < todEspa; i++)
        {
            //pregunta si esta vacio
            if (espacios[i].GetComponent<Espacios>().vacio)
            {

                
                
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

                //Asigna que ya agarro el item
                itemObj.GetComponent<Item>().agarro = true;
                    //se vuelve hijo del espacio y se guarde en el mismo
                    itemObj.transform.parent = espacios[i].transform;

                //Desactivamos el item de la escena
                itemObj.SetActive(false);


                //Activa el cambio de imagen
                espacios[i].GetComponent<Espacios>().ActualizacionEspacio();

                //Decimos qeu ya no esta vacio
               
                    espacios[i].GetComponent<Espacios>().vacio = false;


                return;
            }

        }
    }
    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach(GameObject obj in espacios)
            {
                 Espacios espaciosComponent = obj.GetComponent<Espacios>();
                if (espaciosComponent.gameObject.transform.GetChildCount() == 2)
                {
                    bool estaEquipado = espaciosComponent.transform.GetChild(1).GetComponent<Papa>().getEquipado();
                    if (estaEquipado)
                    {
                        EliminarPapa();
                        GameObject itemEliminado = null;
                        string nombreEliminado = null;
                        Sprite spriteEliminado = null;
                        int vidaEliminada = 0;
                        string descripcionEliminada = null;
                        Tipo tipoEliminado = 0;
                        Rareza rarezaEliminada = 0;
                        Habilidades habilidadesEliminadas = 0;
                        bool equipadoEliminado = false;
                        Agarrar(itemEliminado, nombreEliminado, spriteEliminado, vidaEliminada, descripcionEliminada, tipoEliminado, rarezaEliminada, habilidadesEliminadas, equipadoEliminado);
                        break;

                    }
                }
                //Espada espada = obj.transform.GetChild(1).GetComponent<Espada>();
                //BloqueDiamante bloque = obj.transform.GetChild(1).GetComponent<BloqueDiamante>();

                if(espada.getEquipado())
                {
                    GameObject itemEliminado = null;
                    string nombreEliminado = null;
                    Sprite spriteEliminado = null;
                    int vidaEliminada = 0;
                    string descripcionEliminada = null;
                    Tipo tipoEliminado = 0;
                    Rareza rarezaEliminada = 0;
                    Habilidades habilidadesEliminadas = 0;
                    bool equipadoEliminado = false;
                    Agarrar(itemEliminado, nombreEliminado, spriteEliminado, vidaEliminada, descripcionEliminada, tipoEliminado, rarezaEliminada, habilidadesEliminadas, equipadoEliminado);
                    break;
                }
                if(bloque.getEquipado())
                {
                    GameObject itemEliminado = null;
                    string nombreEliminado = null;
                    Sprite spriteEliminado = null;
                    int vidaEliminada = 0;
                    string descripcionEliminada = null;
                    Tipo tipoEliminado = 0;
                    Rareza rarezaEliminada = 0;
                    Habilidades habilidadesEliminadas = 0;
                    bool equipadoEliminado = false;
                    Agarrar(itemEliminado, nombreEliminado, spriteEliminado, vidaEliminada, descripcionEliminada, tipoEliminado, rarezaEliminada, habilidadesEliminadas, equipadoEliminado);
                    break;
                }
                


            }

            //EliminarPapa();
        }
    }
    void EliminarPapa()
    {
        Destroy(itemAEliminarPapa);
                 /*
                // Iterar a través de los espacios en el inventario
                foreach (GameObject obj in espacios)
                {
                    // Obtener el script del espacio
                    Espacios espacioScript = obj.GetComponent<Espacios>();

                    // Verificar si el espacio no está vacío y está equipado
                    if (obj != null && !espacioScript.vacio && espacioScript.equipado)
                    {


                        GameObject itemEliminado = null;
                        string nombreEliminado = null;
                        Sprite spriteEliminado = null;
                        int vidaEliminada = 0;
                        string descripcionEliminada = null;
                        Tipo tipoEliminado = 0;
                        Rareza rarezaEliminada = 0;
                        Habilidades habilidadesEliminadas = 0;
                        bool equipadoEliminado = false;
                        Agarrar(itemEliminado,  nombreEliminado, spriteEliminado,vidaEliminada,descripcionEliminada,tipoEliminado,rarezaEliminada,habilidadesEliminadas,equipadoEliminado);

                            // Establecer la referencia del item en el espacio a null
                            espacioScript.item = null;

                            // Actualizar el espacio para indicar que ahora está vacío
                            espacioScript.vacio = true;
                            espacioScript.ActualizacionEspacio();
                            break; // Salir del bucle después de eliminar el primer espacio equipado
                    }
                }

    }
    void EliminarBloque()
    {
        Destroy(itemAEliminarBloque);
    }
    void EliminarEspada()
    {
        Destroy(itemAEliminarEspada);
    }

    GameObject itemAEliminarPapa;
     public GameObject ItemAElimPapa(GameObject _itemAEliminarPapa)
    {
        itemAEliminarPapa = _itemAEliminarPapa;
        return itemAEliminarPapa;
    }    
    
    GameObject itemAEliminarBloque;
     public GameObject ItemAElimBloque(GameObject _itemAEliminarBloque)
    {
        itemAEliminarBloque = _itemAEliminarBloque;
        return itemAEliminarBloque;
    }
    GameObject itemAEliminarEspada;
     public GameObject ItemAElimEspada(GameObject _itemAEliminarEspada)
    {
        itemAEliminarEspada = _itemAEliminarEspada;
        return itemAEliminarEspada;
    }*/
}
