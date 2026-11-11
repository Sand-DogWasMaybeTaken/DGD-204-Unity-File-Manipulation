using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    //variables//
    //create a number for the score
    private int score;

    //set the folder path
    private const string DIR_RES = "/Resources"; //-- const(Constants) are fixed and cannot be changed
    //set a file to read
    private const string FILE_SAVES = DIR_RES + "/Saves.txt";
    //create the file path
    private string FILE_PATH_SAVES;

    //make a variables to hold the int as a string
    public string inputnum;

    //add input references for interacting with score and saving
    public InputActionReference scoreplus;
    public InputActionReference save;
    public InputActionReference clear;

    //add text mesh pro variable for previous scores, and one for current score
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI savedScores;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //declare the file path
        FILE_PATH_SAVES = Application.dataPath + FILE_SAVES;

        //set the score
        score = 0;
        //show all the saved scores
        savedScores.text = File.ReadAllText(FILE_PATH_SAVES);
    }

    // Update is called once per frame
    void Update()
    {
        // show the score
        currentScore.text = "" + score;
        //if I press a button score goes up by 1
        if (scoreplus.action.WasPressedThisFrame())
        {
            score++;
        }
        //If I press a button, run the save function
        if (save.action.WasPressedThisFrame())
        {
            Savescore(score);
            score = 0;
            savedScores.text = File.ReadAllText(FILE_PATH_SAVES);
            
        }
        //if I press a button this frame, clear all the saves
        if (clear.action.WasPressedThisFrame())
        {
            Clearsaves();
        }

    }

    public void Savescore(int s)
    {
        inputnum = s.ToString();
        string fileContents = File.ReadAllText(FILE_PATH_SAVES);
        fileContents += inputnum + "\n";
        File.WriteAllText(FILE_PATH_SAVES, fileContents);
        
    }

    public void Clearsaves()
    {
        File.WriteAllText(FILE_PATH_SAVES, "");
    }
}
