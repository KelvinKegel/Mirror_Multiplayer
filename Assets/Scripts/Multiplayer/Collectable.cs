using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Prototipo.Multiplayer
{
    public class Collectable : NetworkBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //Referência para o componente PlayerController
            PlayerController player;
            //Tenta acessar o componente PlayerControler do objeto que entrou no Trigger, e armazenar na referência
            player = other.GetComponent<PlayerController>();
            //Se o valor da referência não for nulo...
            if(player != null)
            {
                //Chamar o método ChangeColor da classe PlayerController
                player.ChangeColor();
            }
        }
    }
}
