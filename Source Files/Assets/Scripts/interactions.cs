using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class interactions
{
    public actions actionObj;

    [TextArea]
    public string responseText;

    public string textToMatch;
    public location teleportLoc = null;

    public List<item> itemsToDisable = new List<item>();
    public List<item> itemsToEnable = new List<item>();

    public List<connection> connectionsToDisable = new List<connection>();
    public List<connection> connectionsToEnable = new List<connection>();
}
