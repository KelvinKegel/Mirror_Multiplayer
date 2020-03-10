using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject player;

    private PlayerController m_PlayerController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        m_PlayerController = player.GetComponent<PlayerController>();

        m_PlayerController.OnTakeDamage += MostraMensagem;
    }

    private void OnDisable()
    {
        m_PlayerController.OnTakeDamage -= MostraMensagem;
    }

    void MostraMensagem()
    {
        Debug.Log("Colidiu com " + gameObject.name);
    }
}
