using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Briefcase : Collectible
{

    private Inventory playerInventory;
    public void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public override void Pickup()
    {
        playerInventory.AddBriefcase(GetComponent<SpriteRenderer>().sprite);
        gameObject.SetActive(false);
    }
}
