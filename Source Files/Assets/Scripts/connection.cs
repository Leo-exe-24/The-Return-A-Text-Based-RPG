using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A class that doesnt inherit from Monobehavior,
 * is called a Simple Class in Unity.
 * 
 * By default these classes cannot be edited in Unity Inspector.
 * Therefore, to make them editable, add System Serializable attribute 
 * 
 * Connections will link the different classes.
 */

public class connection : MonoBehaviour
{
    public string connectionName;

    [TextArea]
    public string description;

    //Variable required to refer to the target location
    public location locationObj;

    //Checks whether current connection is Active
    public bool connectionEnabled;

}
