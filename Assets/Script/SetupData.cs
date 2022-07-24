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
        for (int i = 13; i == 10000; i++)
        {
            if (lines[i].ToString() == "===...===")
            {
                Save1.L1 = i-16;
                Save1.L1 /= 2;
                i = 10000;
            }
        }
        Save1.L2 = lines.Length-22-Save1.L1;
        Save1.L2 /= 2;
        List<SECLV> SECONDLVs = new List<SECLV>();
        for (int i = 21 + 2 * (Save1.L1); i < 21 + 2 * (Save1.L1 + Save1.L2); i = i + 2)
        {
            string[] temp1;
            string[] temp2;
            temp1 = lines[i].Split('/');
            temp2 = lines[i + 1].Split('/');
            string name = temp1[0];
            int X = Convert.ToInt32(temp1[1]);
            int Y = Convert.ToInt32(temp1[2]);
            string FLV = temp1[3];
            string POP = temp1[4];
            string VTP = temp1[5];
            string PVI = temp1[6];
            string POLLSZ = temp1[7];
            string EPSPD = temp2[0];
            string EPBTH = temp2[1];
            string EPPCT = temp2[2];
            string EPTRI = temp2[3];
            string IPSPD = temp2[4];
            string IPBTH = temp2[5];
            string IPTRI = temp2[6];
            string RD = temp2[7];
            string RM = temp2[8];
            SECONDLVs.Add(new SECLV()
            {
                Name = name,
                X = X,
                Y = Y,
                FIRSTLV = FLV,
                Population = Convert.ToDouble(POP),
                VTP = Convert.ToDouble(VTP),
                PVI = Convert.ToDouble(PVI),
                PollSize = Convert.ToDouble(POLLSZ),
                EarlySpeed = Convert.ToDouble(EPSPD),
                EarlyBatch = Convert.ToDouble(EPBTH),
                EarlyPortion = Convert.ToDouble(EPPCT),
                EarlyTrickle = Convert.ToDouble(EPTRI),
                IPSpeed = Convert.ToDouble(IPSPD),
                IPBatch = Convert.ToDouble(IPBTH),
                IPTrickle = Convert.ToDouble(IPTRI),
                RandomDirectionNum = { },
                RandomDirectionWho = { },
                RandomMagnitude = Convert.ToDouble(RM)
            }); 
        }
        List<FIRSTLV> FIRSTLVs = new List<FIRSTLV>();
        for (int i = 16; i < 16 + 2 * (Save1.L1); i = i + 2)
        {
            string[] temp;
            temp = lines[i].Split('/');
            string name = temp[0];
            string abbrv = temp[1];
            int CD = Convert.ToInt32(temp[2]);
            string WTA = temp[3];
            FIRSTLVs.Add(new FIRSTLV() 
            {
                Name = name,
                abbrv = abbrv,
                SECLV = CD,
                WTA = WTA,
            }
            );
        }
    }
}
 public class SECLV
    {
    public string Name;
    public int X;
    public int Y;
    public string FIRSTLV;
    public double Population;
    public double VTP;
    public double PVI;
    public double PollSize;
    public double EarlySpeed;
    public double EarlyBatch;
    public double EarlyPortion;
    public double EarlyTrickle;
    public double IPSpeed;
    public double IPBatch;
    public double IPTrickle;
    public string[] RandomDirectionWho;
    public double[] RandomDirectionNum;
    public double RandomMagnitude;
    }
 public class FIRSTLV
    {
    public string Name;
    public string abbrv;
    public double Population;
    public double SECLV;
    public string WTA;
    public double VTP;
    public double PVI;
    public double PollSize;
    public double EarlySpeed;
    public double EarlyBatch;
    public double EarlyPortion;
    public double EarlyTrickle;
    public double IPSpeed;
    public double IPBatch;
    public double IPTrickle;
    public string[] RandomDirectionWho;
    public double[] RandomDirectionNum;
    public double RandomMagnitude;
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


