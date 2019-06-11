using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class CSVmaker
 
{
    
    private List<string[]> rowData = new List<string[]>();
    private DateTime creationTime;
    private float time;

    public void Init()
    {
        string[] titleRow = new [] {"Goal", "Guess", "Type","Time"};
        rowData.Add(titleRow);
        time = 0;
        creationTime = System.DateTime.Now;
    }

    public void addEntry(int goal, int guess, string type)
    {
        time += Time.deltaTime;
        string[] newRow = new string[4];
        newRow[0] = goal.ToString();
        newRow[1] = guess.ToString();
        newRow[2] = type;
        newRow[3] = time.ToString();
        rowData.Add(newRow);
    }

    public void SavetoCSV()
    {
        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));

        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }
    
    private string GetCreationTime()
    {
        return creationTime.GetHashCode().ToString();
    }
    
    private string getPath()
    {
        #if UNITY_EDITOR
                return Application.dataPath + "/CSV/" + "Saved_data" + GetCreationTime() + ".csv";
        #elif UNITY_ANDROID
                return Application.persistentDataPath + "Saved_data" + GetCreationTime() + ".csv";
        #elif UNITY_IPHONE
                return Application.persistentDataPath + "/" + "Saved_data" + GetCreationTime() + ".csv";
        #else
                return Application.dataPath + "/" + "Saved_data" + GetCreationTime() + ".csv";
        #endif
    }


}
