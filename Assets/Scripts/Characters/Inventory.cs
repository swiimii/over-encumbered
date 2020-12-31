using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] int numOfBriefcases;
    [SerializeField] int briefcasesNeeded;
    [SerializeField] Text textBox;
    public List<Sprite> inventory;

    [SerializeField] float movementSpeedReduction = 0.1f;
    public void AddBriefcase(Sprite briefcase)
    {
        numOfBriefcases += 1;
        AddToInventory(briefcase);
        DecrementBriefcaseTracker();
        GetComponent<Animator>().SetInteger("numBriefcases", numOfBriefcases);
        GetComponent<Character>().movementSpeed -= movementSpeedReduction;
    }
    public void AddToInventory(Sprite item)
    {
        inventory.Add(item);
    }
    public void DecrementBriefcaseTracker()
    {
        textBox.text = (briefcasesNeeded-numOfBriefcases).ToString();
    }
    public bool FoundAllNeededBriefcases()
    {
        return numOfBriefcases >= briefcasesNeeded;
    }
}
