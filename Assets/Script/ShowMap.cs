using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowMap : MonoBehaviour
{
    [SerializeField] double canvax, canvay;
    [SerializeField] double distxcount, distycount;
    double per_x, per_y;
    public GameObject Tile;
    public void DetermineSize(int distxcount, int distycount, double canvax, double canvay) 
    {
        per_x = canvax / (double)distxcount; 
        per_y = canvay / (double)distycount;
    }
    public void ReadFile(int distxcount, int distycount, int startline, int endline)
    {
        string filePath;
        string[] lines = new string[10000];
        filePath = GENERAL.MapFilePath;
        lines = File.ReadAllLines(filePath);
        string[] DName = new string[10000];
        int[] DX = new int[10000];
        int[] DY = new int[10000];
        for (int i = startline-1; i <= endline-1; i++) 
        {
            string[] Entry = lines[i].Split('/');
            DName[i] = Entry[0];
            DX[i] = Convert.ToInt32(Entry[1]);
            DY[i] = Convert.ToInt32(Entry[2]);
        }
    }
    public void ProjectMap() 
    {
        GameObject go = Instantiate(Tile) as GameObject;
    }

    void Start()
    {
        ProjectMap();
    }

}
