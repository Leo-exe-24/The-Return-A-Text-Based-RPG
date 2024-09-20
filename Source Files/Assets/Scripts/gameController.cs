using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For access to GUI in Unity
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public player playerObj;

    //player types commmands into this
    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    //list of all available actions
    public actions[] actionArray;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        logText.text = introText;
        displayLocation();

        //Text entry field needs to be active for the player to type
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //if u dont pass a value for additive, it will automatically substitute the text, else adds
    public void displayLocation( bool additive = false)
    {
        //Gets Current Location Info
        string description = playerObj.currentLocation.description + "\n";

        //Gets the list of all the available connections for the current Location
        description += playerObj.currentLocation.getConnectionsText();
        description += playerObj.currentLocation.getItemText();

        if (additive)
            currentText.text = currentText.text + "\n==>   " + description;
        else
            currentText.text = "\n"+description;
    }

    public void textEntered()
    {
        Debug.Log("text entered");
        logCurrentText();
        processInput(textEntryField.text);

        //Need to reset the text field once entered
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void logCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n";
        //unity color codes are in hexadecimal
        logText.text += "<color=#aaccaaff><b>" + textEntryField.text +"</b></color>";
    }

    void processInput(string input)
    {
        input = input.ToLower();

        //input should be in verb-noun pair
        //string split method gives an array of parameters split using delimiter

        //delimiter array
        char[] delimeter = { ' ' };

        //the split words are stored here
        string[] separatedWords = input.Split(delimeter);

        // process commands separated words
        foreach(actions action in actionArray)
        {
            if(action.keyword.ToLower() == separatedWords[0])
            {
                if(separatedWords.Length > 1)
                {
                    action.respondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.respondToInput(this, "");
                }
                return;
            }
        }

        //if the process fails
        currentText.text = "<color=#ff726fff> (O.O) Nothing Happened!\n\t\tHaving Trouble? type <b>\'Help\'</b> </color>";
    }
}
