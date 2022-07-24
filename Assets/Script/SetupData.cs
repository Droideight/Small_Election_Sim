using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class SetupData : MonoBehaviour
{
    GENERAL Save1 = new GENERAL();
    public void LoadMapSetup(string filepath)
    {
        string[] lines = new string[10000];
        lines = File.ReadAllLines(filepath);
        Save1.NationName = lines[1];
        Save1.MapX = Convert.ToInt32(lines[4]);
        Save1.MapY = Convert.ToInt32(lines[5]);
        Save1.Layers = Convert.ToInt32(lines[8]);
        Save1.LayerList = lines[11].Split('/');
        for (int i = 14; i == 10000; i++)
        {
            if (lines[i].ToString() == "===...===")
            {
                Save1.L1 = i-17;
                Save1.L1 /= 2;
                i = 10000;
            }
        }
        Save1.L2 = lines.Length-22-Save1.L1;
        Save1.L2 /= 2;
    }
}
 public class SECLV
    {
    string Name;
    string FIRSTLV;
    double Population;
    double VTP;
    double PVI;
    double PollSize;
    double[] PollAVG;
    double[] EarlyPollAVG;
    double EarlySpeed;
    double EarlyBatch;
    double EarlyPortion;
    double EarlyTrickle;
    double IPSpeed;
    double IPBatch;
    double IPTrickle;
    double[] RandomDirection;
    double RandomMagnitude;
    }
 public class FIRSTLV
    {
    string Name;
    double Population;
    double SECLV;
    double WTA;
    double VTP;
    double PVI;
    double PollSize;
    double[] PollAVG;
    double[] EarlyPollAVG;
    double EarlySpeed;
    double EarlyBatch;
    double EarlyPortion;
    double EarlyTrickle;
    double IPSpeed;
    double IPBatch;
    double IPTrickle;
    double[] RandomDirection;
    double RandomMagnitude;
    }
 public class GENERAL
 {
    public string FilePath = @"C:\Users\Pin\Desktop\Unity Election Simulator\Small_Election_Sim\Assets\Datas\Map_Example.txt";
    public string NationName;
    public int MapX;
    public int MapY;
    public int Layers;
    public string[] LayerList = new string[2];
    public int L1;
    public int L2;
 }


