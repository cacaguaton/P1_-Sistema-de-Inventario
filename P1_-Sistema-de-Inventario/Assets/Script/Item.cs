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

    //Saber si el objeto esta equipado
    private bool equipado;

    public bool getEquipado()
    {
        return equipado;
    }

    //Aqui guardamos el item en la mano
    [HideInInspector]
    public GameObject itemUsoPapa;
    [HideInInspector]
    public GameObject itemUsoBloque;
    [HideInInspector]
    public GameObject itemUsoEspada;

    //item que se activa
    [HideInInspector]
    public GameObject item;

    //preguntsmod
    public bool usoPorPlayer;


    private void Start()
    {
        //asignamos el game object al  game object que tenemos en unity
        itemUsoPapa = GameObject.FindWithTag("UsoPapa");
        itemUsoBloque = GameObject.FindWithTag("UsoBloque");
        itemUsoEspada = GameObject.FindWithTag("UsoEspada");
        //Si queremos activar la papa
        if (this.tag == "Papa")
        {
            if (!usoPorPlayer)
            {
                //pasamos por lodos lo hijos del player para poder saber si es el item que buscamos
                int todosItems = itemUsoPapa.transform.childCount;
                for (int i = 0; i < todosItems; i++)
                {
                    //pregunta si el nombre es igual para saber cual tenemos que activar
                    if (itemUsoPapa.transform.GetChild(i).gameObject.GetComponent<Item>().nombre == nombre)
                    {
                        //Decimos que es el mismo item, el que tenemos en la mano y el que recogimos
                        item = itemUsoPapa.transform.GetChild(i).gameObject;
                    }

                }
            }
        }
        
        //Si queremos activar el bloque
        if (this.tag == "BloqueDiamante")
        {
            if (!usoPorPlayer)
            {
                //pasamos por lodos lo hijos del player para poder saber si es el item que buscamos
                int todosItems = itemUsoBloque.transform.childCount;
                for (int i = 0; i < todosItems; i++)
                {
                    //pregunta si el nombre es igual para saber cual tenemos que activar
                    if (itemUsoBloque.transform.GetChild(i).gameObject.GetComponent<Item>().nombre == nombre)
                    {
                        //Decimos que es el mismo item, el que tenemos en la mano y el que recogimos
                        item = itemUsoBloque.transform.GetChild(i).gameObject;
                    }

                }
            }
        }
        
        //Si queremos activar la espada
        if (this.tag == "Espada")
        {
            if (!usoPorPlayer)
            {
                //pasamos por lodos lo hijos del player para poder saber si es el item que buscamos
                int todosItems = itemUsoEspada.transform.childCount;
                for (int i = 0; i < todosItems; i++)
                {
                    //pregunta si el nombre es igual para saber cual tenemos que activar
                    if (itemUsoEspada.transform.GetChild(i).gameObject.GetComponent<Item>().nombre == nombre)
                    {
                        //Decimos que es el mismo item, el que tenemos en la mano y el que recogimos
                        item = itemUsoEspada.transform.GetChild(i).gameObject;
                    }

                }
            }
        }
    }

    //actualizamos la logica en tiempo real
    private void Update()
    {
        //preguntamos si esta equipado
        if (equipado)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                equipado = false;
            }
            if(equipado == false)
            {
                gameObject.SetActive(false);
            }
            /*
            if (item.gameObject.GetComponent<Item>().nombre == "Papa")
        {
            itemUsoBloque.gameObject.SetActive(false);
            itemUsoEspada.gameObject.SetActive(false);

        }
        if(item.gameObject.GetComponent<Item>().nombre == "BloqueDiamante")
        {
            itemUsoPapa.gameObject.SetActive(false);
            itemUsoEspada.gameObject.SetActive(false);
        }
        if(item.gameObject.GetComponent<Item>().nombre == "Espada")
        {
            itemUsoPapa.gameObject.SetActive(false);
            itemUsoBloque.gameObject.SetActive(false);
        }
            
            switch(item.gameObject.GetComponent<Item>().nombre)
            {
                case "Papa":
                    itemUsoBloque.gameObject.SetActive(false);
                    itemUsoEspada.gameObject.SetActive(false);
                    break;
                case "BloqueDiamante":
                    itemUsoPapa.gameObject.SetActive(false);
                    itemUsoEspada.gameObject.SetActive(false);
                    break;
                case "Espada":
                    itemUsoPapa.gameObject.SetActive(false);
                    itemUsoBloque.gameObject.SetActive(false);
                    break;
            }*/
        }


    }

    public void ItemUso()
    {
        //Usamos esto para abarcar todos los items
        if (vida >= 1)
        {
            //Se equipa y activa en el game
            item.SetActive(true);
            
            //cambiamos su estado a equipado
            item.GetComponent<Item>().equipado = true;
        }
    }
}
