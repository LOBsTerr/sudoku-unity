using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayHelper
{
    public static bool findItemInArray(int[] array, int n) { 
        return Array.Find(array, element => element == n) != 0;
    }

    //public static bool findInRange();
}
