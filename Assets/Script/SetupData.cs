using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class SetupData : MonoBehaviour
{
    public GENERAL Save1 = new GENERAL();
    public static List<SECLV> SECONDLVs = new List<SECLV>();
    public static List<FIRSTLV> FIRSTLVs = new List<FIRSTLV>();
    public List<Candidate> Candidates = new List<Candidate>();
    public List<Party> Parties = new List<Party>(); //includes "others"
    public Setting_Data_Shower SDS;

    public void LoadMapSetup(string filepath)
    {
        string[] lines = new string[10000];
        lines = File.ReadAllLines(filepath);
        Save1.NationName = lines[1];
        Save1.MapX = Convert.ToInt32(lines[4]);
        Save1.MapY = Convert.ToInt32(lines[5]);
        Save1.Layers = Convert.ToInt32(lines[8]);
        Debug.Log(lines[11]);
        GENERAL.LayerList = lines[11].Split('/');
        Debug.Log(GENERAL.LayerList[1]);
        for (int i = 13; i <= 10000; i++)
        {
            if (lines[i].ToString() == "===...===")
            {
                Save1.L1 = i - 16;
                Save1.L1 /= 2;
                i = 10000;
            }
        }
        Save1.L2 = lines.Length - 21 - 2*Save1.L1;
        Save1.L2 /= 2;

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
            int QI = Convert.ToInt32(temp1[4]);
            string POP = temp1[5];
            string VTP = temp1[6];
            string PVI = temp1[7];
            string POLLSZ = temp1[8];
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
                QualityImpact = QI,
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
            }) ; 
        }

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
    public void LoadCandidate(string filepath)
    {
        string[] lines = new string[10000];
        lines = File.ReadAllLines(filepath);
        for (int i = 5; i <= 1000; i++)
        {
            if (lines[i].ToString() == "===...===")
            {
                Save1.PartyQTY = i - 6;
                i = 1000;
            }
        }
        Save1.CandidateQTY = lines.Length - 10 - Save1.PartyQTY;
        Save1.CandidateQTY /= 3;

        for (int i = 10+ Save1.PartyQTY; i < 10 + Save1.PartyQTY + 3*(Save1.CandidateQTY); i = i + 3)
        {
            string[] temp2;
            string[] temp3;
            temp2 = lines[i + 1].Split('/');
            temp3 = lines[i + 2].Split('/');
            string name = temp2[0];
            int partyid = Convert.ToInt32(temp2[1]);
            int layer = Convert.ToInt32(temp2[2]);
            string Flayer = temp3[0];
            string Slayer = temp3[1];
            double pollpct = Convert.ToDouble(temp3[2]);
            double evpct = Convert.ToDouble(temp3[3]);
            double quality = Convert.ToDouble(temp3[4]);
            double investment = Convert.ToDouble(temp3[5]);
            double enthusiasm = Convert.ToDouble(temp3[6]);
            Candidates.Add(new Candidate()
            {
                Name = name,
                PartyID = partyid,
                Layer = layer,
                FLayer = Flayer,
                SLayer = Slayer,
                PollPCT = pollpct,
                EVPCT = evpct,
                Quality = quality,
                Investment = investment,
                Enthusiasm = enthusiasm
            }
            );
        }

        for (int i = 5; i < 6 + Save1.PartyQTY; i++)
        {
            string[] temp;
            temp = lines[i].Split('/');
            int ID = Convert.ToInt32(temp[0]);
            string name = temp[1];
            string abbrv = temp[2];
            string people = temp[3];
            string color = temp[4];
            Parties.Add(new Party()
            {
                Name = name,
                PartyID = Convert.ToInt32(ID),
                Abbrv = abbrv,
                People = people,
                Color = color,
            }
            );
        }
    }
    public void GameOpenSetup()
    {
        LoadMapSetup(Save1.MapFilePath);
        LoadCandidate(Save1.CandidateFilePath);
        SDS.MapOptionSet();
    }
}
public class SECLV
    {
    public new string Name;
    public int X;
    public int Y;
    public string FIRSTLV;
    public double QualityImpact;
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
    public new string Name;
    public string abbrv;
    public double QualityImpact;
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
public class Candidate
{
    public string Name;
    public int PartyID;
    public int Layer;
    public string FLayer;
    public string SLayer;
    public double PollPCT;
    public double EVPCT;
    public double Quality;
    public double Investment;
    public double Enthusiasm;
}
public class Party
{
    public int PartyID;
    public string Name;
    public string Abbrv;
    public string People;
    public string Color;
}
public class GENERAL
 {
    public string MapFilePath = @"C:\Users\Pin\Desktop\Unity Election Simulator\Small_Election_Sim\Assets\Datas\Map_Example.txt";
    public string CandidateFilePath = @"C:\Users\Pin\Desktop\Unity Election Simulator\Small_Election_Sim\Assets\Datas\Candidate_Example.txt";
    public string NationName;
    public int MapX;
    public int MapY;
    public int Layers;
    public static string[] LayerList = new string[2];
    public int L1;
    public int L2;
    public int CandidateQTY;
    public int PartyQTY; //Excluding "Other"
 }


