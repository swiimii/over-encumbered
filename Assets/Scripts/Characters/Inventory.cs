using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int numOfBriefcases;
    public List<Sprite> inventory;

    public void AddBriefcase(Sprite briefcase)
    {
        numOfBriefcases += 1;
        AddToInventory(briefcase);
    }
    public void AddToInventory(Sprite item)
    {
        inventory.Add(item);
    }
}
