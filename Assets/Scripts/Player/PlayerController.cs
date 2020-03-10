using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public event Action OnTakeDamage;    

    [SerializeField]
    private int health = 100;

    private void OnEnable()
    {
        OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        OnTakeDamage -= TakeDamage;
    }

    public void TakeDamage()
    {
        health -= 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Cria uma variável temporária do tipo NetworkIdentity
        Collectable collectable;
        //Tenta acessar o componente "NetworkIdentity" do objeto que ativou o trigger
        collectable = other.GetComponent<Collectable>();
        //Se o valor da variável não for null...
        if (collectable != null)
        {
            if(OnTakeDamage != null)
            {
                OnTakeDamage();
            }
        }       
    }
}
