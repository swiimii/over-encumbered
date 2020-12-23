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
    private void Start() {
        
    }
    public void AddBriefcase(Sprite briefcase)
    {
        numOfBriefcases += 1;
        AddToInventory(briefcase);
        DecrementBriefcaseTracker();
        GetComponent<Animator>().SetInteger("numBriefcases", numOfBriefcases);
    }
    public void AddToInventory(Sprite item)
    {
        inventory.Add(item);
    }
    public void DecrementBriefcaseTracker()
    {
        textBox.text = (briefcasesNeeded-numOfBriefcases).ToString();
    }
}
