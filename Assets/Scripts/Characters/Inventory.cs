using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int numOfBriefcases;

    public void AddBriefcase()
    {
        numOfBriefcases += 1;
    }
}
