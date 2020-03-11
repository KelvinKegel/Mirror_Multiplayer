﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private bool isCarrying = false;

    [SerializeField]private GameObject pickup;

    public Transform itemPosition;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!isCarrying) //isCarrying == false
            {
                Collect();
            }
            else
            {
                Drop();
            }
        }
    }
    //[Command]
    void Collect()
    {
        if(pickup != null)
        {
            Collectable collectable = pickup.GetComponent<Collectable>();

            if (collectable.IsActivated)
            {
                collectable.CollectObject(itemPosition);

                isCarrying = true;
            }
            else
                return;
        }
    }

    //[Command]
    void Drop()
    {
        if(pickup != null)
        {
            Collectable collectable = pickup.GetComponent<Collectable>();
            
            if(collectable.IsActivated)
            {
                collectable.Drop(transform);

                isCarrying = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collectable")
        {
            if(!isCarrying)
                pickup = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Collectable")
        {
            if(pickup != null && pickup == other.gameObject)
            {
                if(!isCarrying)
                {
                    pickup = null;
                }
            }
        }
    }
}
