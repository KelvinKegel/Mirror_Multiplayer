using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerDetection : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Cria uma variável temporária do tipo NetworkIdentity
        NetworkIdentity identity;
        //Tenta acessar o componente "NetworkIdentity" do objeto que ativou o trigger
        identity = other.GetComponent<NetworkIdentity>();
        //Se o valor da variável não for null...
        if(identity != null)
        {
            //Mostrar esta mensagem
            Debug.Log("Colidiu com outro NetworkIdentity " + other.gameObject.name);
        }
        //Se for null...
        else
        {
            //Mostrar esta mensagem
            Debug.Log("Não tem NetworkIdentity");
        }
    }
}
