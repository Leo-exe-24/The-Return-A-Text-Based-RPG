using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable Objects stores data independently as assets
//can also execute code
//Its serializable by default
//Can add menu items

//abstract prevents from creating an instance of this class
public abstract class actions : ScriptableObject
{
    public string keyword;

    //whichever class inherits actions, must implement the method below
    public abstract void respondToInput(gameController controllerObj, string noun);
}
