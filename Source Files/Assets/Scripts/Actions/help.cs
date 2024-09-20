using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to create the help asset in the project, we use createassetmenu
[CreateAssetMenu(menuName = "actions/help")]
public class help : actions
{
    //override redefines a method in the base class
    public override void respondToInput(gameController controllerObj, string noun)
    {
        controllerObj.currentText.text = "<color=#0000ffff> (^_^) Type a Verb followed by a noun (eg-: \"Go North\")";
        controllerObj.currentText.text += "\n  Allowed Verbs --> <b>\'Go\'</b>, <b>\'Examine\'</b>, <b>\'Get\'</b>, <b>\'Use\'</b>, <b>\'Inventory\'</b>, <b>\'TalkTo\'</b>, <b>\'Say\'</b>, <b>\'Give\'</b>, <b>\'Read\'</b>, <b>\'Help\'</b>  </color>";
    }
}
