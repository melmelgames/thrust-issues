using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] private int value;

    public int GetValue()
    {
        return value;
    }
}
