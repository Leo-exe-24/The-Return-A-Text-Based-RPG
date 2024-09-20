using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "actions/goAction")]
public class goAction : actions
{
    
    public override void respondToInput(gameController controllerObj, string noun)
    {
       if(controllerObj.playerObj.changeLocation(controllerObj, noun))
        {
            controllerObj.displayLocation();
        }
        else
        {
            controllerObj.currentText.text = "<color=#ff726fff> (O.O) Thou shall not pass! You cannot go there! </color>";
        }
    }
}
