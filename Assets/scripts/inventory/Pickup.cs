using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    Inventory inventory;
    public Item item;

    private void Start()
    {
        GameObject inv = GameObject.FindWithTag("Inventory");

        if (inv != null)
        {
            inventory = inv.GetComponent<Inventory>();
        }

        if (inv == null)
        {
            Debug.Log("cannot find inventory lol");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("the item we adding " + item);
        if (other.tag == "Player")
        {
            inventory.AddItem(item);
        }

        Destroy(gameObject);
    }
}
