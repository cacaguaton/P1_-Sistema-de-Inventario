using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Item
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
}
