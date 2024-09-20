using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    //Each location can have multiple connections
    public connection[] connectionsArray;

    //The number of items varies during gameplay. Therefore we use List.
    public List<item> items = new List<item>();

    public string getItemText()
    {
        if(items.Count == 0)
        {
            return "";
        }

        string result = "You see";
        bool first = true;
        foreach(item availableItem in items)
        {
            if (availableItem.itemEnabled)
            {
                if (!first)
                    result += " and ";
                result += availableItem.description.ToLower();
                first = false;
            }
        }
        result += " \n";
        return result;
    }

    public string getConnectionsText()
    {
        string result = "";

        foreach(connection connectionItem in connectionsArray)
        {
            if(connectionItem.connectionEnabled)
            {
                result += connectionItem.description + "\n";
            }
        }

        return result;
    }

    internal bool hasItem(item selectedItem)
    {
        foreach( item i in items)
        {
            if ( (i == selectedItem) && (selectedItem.itemEnabled))
            {
                return true;
            }
        }
        return false;
    }

    public connection getConnection(string connectionNoun)
    {
        //Goes through the list of connections linked in the inspector
        foreach(connection connected in connectionsArray)
        {
            //if connection is valid, returns it, else null
            if (connected.connectionName.ToLower() == connectionNoun.ToLower())
                return connected;
        }
        return null;
    }
}
