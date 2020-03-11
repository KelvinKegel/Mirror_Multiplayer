using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private bool isCarried = false;
    private bool isActivated = true;

    public bool IsCarried
    {
        get { return isCarried; }
    }

    public bool IsActivated
    {
        get { return isActivated; }
    }

    private Transform holder;

    void Awake()
    {
        if(transform.parent != null)
        {
            holder = transform.parent;
        }
    }    

    public void CollectObject(Transform carryPosition)
    {
        isCarried = true;

        transform.parent = carryPosition;
        transform.localPosition = Vector3.zero;
    }

    public void Drop(Transform dropLocation)
    {
        isCarried = false;

        transform.parent = holder;

        Vector3 dropPosition = new Vector3(dropLocation.position.x, 0, dropLocation.position.z);

        transform.localPosition = dropPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Plataforma" && isCarried == false)
        {
            Debug.Log("Está na plataforma");

            isActivated = false;

            GameManager.Instance.ObjectCollected();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Plataforma")
        {
            Debug.Log("Não está na plataforma");
        }
    }
}
