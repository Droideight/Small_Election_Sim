using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections.ObjectModel;

public class Setting_SetupData : MonoBehaviour
{
    public static List<SECLV> SECONDLVs = new List<SECLV>();
    public static List<FIRSTLV> FIRSTLVs = new List<FIRSTLV>();
    public static List<Candidate> Candidates = new List<Candidate>();
    public static List<Party> Parties = new List<Party>(); //includes "others"
    public Setting_Data_Shower SDS;


    public void LoadMapSetup(string filepath)
    {
        string[] lines = new string[10000];
        lines = File.ReadAllLines(filepath);
        GENERAL.NationName = lines[1];
        GENERAL.MapX = Convert.ToInt32(lines[4]);
        GENERAL.MapY = Convert.ToInt32(lines[5]);
        GENERAL.Layers = Convert.ToInt32(lines[8]);
        GENERAL.LayerList = lines[11].Split('/').ToList();
        for (int i = 13; i <= 10000; i++)
        {
            if (lines[i].ToString() == "===...===")
            {
                GENERAL.L1 = i - 16;
                GENERAL.L1 /= 2;
                i = 10000;
            }
        }
        GENERAL.L2 = lines.Length - 21 - 2* GENERAL.L1;
        GENERAL.L2 /= 2;
        for (int i = 21 + 2 * (GENERAL.L1); i < 21 + 2 * (GENERAL.L1 + GENERAL.L2); i = i + 2)
        {
            string[] temp1;
            string[] temp2;
            temp1 = lines[i].Split('/');
            temp2 = lines[i + 1].Split('/');
            int subID = Convert.ToInt32(temp1[0]);
            string name = temp1[1];
            int X = Convert.ToInt32(temp1[2]);
            int Y = Convert.ToInt32(temp1[3]);
            int FLV = Convert.ToInt32(temp1[4]);
            int QI = Convert.ToInt32(temp1[5]);
            string POP = temp1[6];
            string VTP = temp1[7];
            string PVI = temp1[8];
            string POLLSZ = temp1[9];
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
                SUBID = subID,
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

        for (int i = 16; i < 16 + 2 * (GENERAL.L1); i = i + 2)
        {
            string[] temp;
            temp = lines[i].Split('/');
            int ID = Convert.ToInt32(temp[0]);
            string name = temp[1];
            string abbrv = temp[2];
            int CD = Convert.ToInt32(temp[3]);
            string WTA = temp[4];
            FIRSTLVs.Add(new FIRSTLV() 
            {
                ID = ID,
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
                GENERAL.PartyQTY = i - 6;
                i = 1000;
            }
        }
        GENERAL.CandidateQTY = lines.Length - 10 - GENERAL.PartyQTY;
        GENERAL.CandidateQTY /= 3;

        for (int i = 10+ GENERAL.PartyQTY; i < 10 + GENERAL.PartyQTY + 3*(GENERAL.CandidateQTY); i = i + 3)
        {
            string[] temp2;
            string[] temp3;
            temp2 = lines[i + 1].Split('/');
            temp3 = lines[i + 2].Split('/');
            int ID = Convert.ToInt32(temp2[0]);
            string name = temp2[1];
            int partyid = Convert.ToInt32(temp2[2]);
            int layer = Convert.ToInt32(temp2[3]);
            int Flayer = Convert.ToInt32(temp3[0]);
            int Slayer = Convert.ToInt32(temp3[1]);
            double pollpct = Convert.ToDouble(temp3[2]);
            double evpct = Convert.ToDouble(temp3[3]);
            double quality = Convert.ToDouble(temp3[4]);
            double investment = Convert.ToDouble(temp3[5]);
            double enthusiasm = Convert.ToDouble(temp3[6]);
            Candidates.Add(new Candidate()
            {
                ID = ID,
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

        for (int i = 5; i < 6 + GENERAL.PartyQTY; i++)
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
        CalculateCandidateAVG();
    }
    public void GameOpenSetup()
    {
        LoadMapSetup(GENERAL.MapFilePath);
        LoadCandidate(GENERAL.CandidateFilePath);
        SDS.MapOptionSet();
    }
    public void CalculateCandidateAVG()
    {
        int MaxID = 0;
        //State List
        List<double> POLLPCT1 = new List<double>();
        List<double> EVPCT1 = new List<double>();
        List<double> QUALITY1 = new List<double>();
        List<double> INVEST1 = new List<double>();
        List<double> ENTHUSIASM1 = new List<double>();
        //National List
        List<double> POLLPCT0 = new List<double>();
        List<double> EVPCT0 = new List<double>();
        List<double> QUALITY0 = new List<double>();
        List<double> INVEST0 = new List<double>();
        List<double> ENTHUSIASM0 = new List<double>();
        //Modifying Area
        List<double> POPULATION = new List<double>();
        List<double> VTP = new List<double>();
        List<double> POPVTP = new List<double>();
        List<int> CANBEXAM = new List<int>();
        int k = 0;
        double POLLPCT = 0;
        double EVPCT = 0;
        double QUALITY = 0;
        double INVEST = 0;
        double ENTHUSIASM = 0;
        int Serial = 0;
        foreach (Candidate a in Candidates) 
        { 
            if (a.ID > MaxID) { MaxID = a.ID; }
        }
        for (int i = 0; i <= MaxID; i++) //GOING THROUGH ALL IDs
        {
            //FIND TARGET ID
            CANBEXAM.Clear();
            foreach (Candidate CandBeExam in Candidates)
            {
                CANBEXAM.Add(CandBeExam.ID);
            }
            Serial = CANBEXAM.LastIndexOf(i);
            //
            //IF TARGET ID IS A NATIONAL CANDIDATE
            if (Candidates[Serial].Layer == 0)
            {
                POLLPCT0.Clear();
                EVPCT0.Clear();
                QUALITY0.Clear();
                INVEST0.Clear();
                ENTHUSIASM0.Clear();
                POPULATION.Clear();
                VTP.Clear();
                POPVTP.Clear();
                POLLPCT = 0;
                EVPCT = 0;
                QUALITY = 0;
                INVEST = 0;
                ENTHUSIASM = 0;
                k = 0;
                foreach (SECLV A in SECONDLVs)
                {
                    POPULATION.Add(A.Population);
                    VTP.Add(A.VTP);
                }
                for (int l = 0; l < POPULATION.Count; l++) //Calculate voting bloc
                {
                    POPVTP.Add(POPULATION[l] * VTP[l]);
                }
                foreach (Candidate CandBeSearched in Candidates) // check all entry that has the ID
                {
                    if (CandBeSearched.ID == i) // if an entity belongs to a candidate, then add
                    {
                        POLLPCT0.Add(CandBeSearched.PollPCT);
                        EVPCT0.Add(CandBeSearched.EVPCT);
                        QUALITY0.Add(CandBeSearched.Quality);
                        INVEST0.Add(CandBeSearched.Investment);
                        ENTHUSIASM0.Add(CandBeSearched.Enthusiasm);
                    }                           
                }
                //NAT: Computing Result
                foreach (double entry in POLLPCT0) //Aggregate ALL entries
                {
                    POLLPCT += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                POLLPCT /= POPVTP.Sum();
                k = 0;
                foreach (double entry in EVPCT0)
                {
                    EVPCT += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                EVPCT /= POPVTP.Sum();
                k = 0;
                foreach (double entry in QUALITY0)
                {
                    QUALITY += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                QUALITY /= POPVTP.Sum();
                k = 0;
                foreach (double entry in INVEST0)
                {
                    INVEST += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                INVEST /= POPVTP.Sum();
                k = 0;
                foreach (double entry in ENTHUSIASM0)
                {
                    ENTHUSIASM += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                ENTHUSIASM /= POPVTP.Sum();
                k = 0;
                //Write Result
                foreach (Candidate a in Candidates)
                {
                    if (a.ID == i)
                    {
                        a.PollPCT0 = POLLPCT;
                        a.EVPCT0 = EVPCT;
                        a.Quality0 = QUALITY;
                        a.Investment0 = INVEST;
                        a.Enthusiasm0 = ENTHUSIASM;
                    }
                }
            }
            else if (Candidates[Serial].Layer == 1)
            {
                POLLPCT1.Clear();
                EVPCT1.Clear();
                QUALITY1.Clear();
                INVEST1.Clear();
                ENTHUSIASM1.Clear();
                POPULATION.Clear();
                VTP.Clear();
                POPVTP.Clear();
                POLLPCT = 0;
                EVPCT = 0;
                QUALITY = 0;
                INVEST = 0;
                ENTHUSIASM = 0;
                k = 0;
                foreach (Candidate CandBeSearched in Candidates) // check all entry that has the ID
                {
                    //Gathering DataList
                    if (CandBeSearched.FLayer == Candidates[Serial].FLayer) //if an entity is from a state
                    {
                        if (CandBeSearched.ID == i) // if an entity belongs to a candidate
                        {
                            POLLPCT1.Add(CandBeSearched.PollPCT);
                            EVPCT1.Add(CandBeSearched.EVPCT);
                            QUALITY1.Add(CandBeSearched.Quality);
                            INVEST1.Add(CandBeSearched.Investment);
                            ENTHUSIASM1.Add(CandBeSearched.Enthusiasm);
                            int NO = 0;
                            foreach (SECLV A in SECONDLVs)
                            {
                                if (A.FIRSTLV == Candidates[Serial].FLayer)
                                {
                                    if (A.SUBID == CandBeSearched.SLayer) NO = SECONDLVs.IndexOf(A);
                                }
                            }
                            POPULATION.Add(SECONDLVs[NO].Population);
                            VTP.Add(SECONDLVs[NO].VTP);
                        }
                    }                    
                }
                //Computing Result
                foreach (double entry in POLLPCT1)
                {
                    POLLPCT += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                for (int l = 0; l < POPULATION.Count; l++)
                {
                    POPVTP.Add(POPULATION[l] * VTP[l]);
                }
                POLLPCT /= POPVTP.Sum();
                k = 0;
                foreach (double entry in EVPCT1)
                {
                    EVPCT += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                EVPCT /= POPVTP.Sum();
                k = 0;
                foreach (double entry in QUALITY1)
                {
                    QUALITY += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                QUALITY /= POPVTP.Sum();
                k = 0;
                foreach (double entry in INVEST1)
                {
                    INVEST += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                INVEST /= POPVTP.Sum();
                k = 0;
                foreach (double entry in ENTHUSIASM1)
                {
                    ENTHUSIASM += entry * POPULATION[k] * VTP[k];
                    k++;
                }
                ENTHUSIASM /= POPVTP.Sum();
                k = 0;
                //Write Result in singular state
                foreach (Candidate a in Candidates)
                {
                    if (a.ID == i)
                    {
                        a.PollPCT1 = POLLPCT;
                        a.EVPCT1 = EVPCT;
                        a.Quality1 = QUALITY;
                        a.Investment1 = INVEST;
                        a.Enthusiasm1 = ENTHUSIASM;
                    }
                }
            }
            //Current Issue: Candidate's entry has to be sorted to work
        }
    }
    public void SortCandidateByID()
    {
        List<Candidate> Sorted = Candidates.OrderBy(x => x.FLayer).ThenBy(x => x.SLayer).ThenBy(x => x.ID).ToList();
        Candidates = Sorted;
    }
    public void WriteCandidate(string filepath, int variI, string variS, int varno) 
    {
        
    }
}
public class SECLV
    {
    public int SUBID;
    public new string Name;
    public int X;
    public int Y;
    public int FIRSTLV;
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
    public int ID;
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
    public int FLayer;
    public int SLayer;
    public double PollPCT;
    public double EVPCT;
    public double Quality;
    public double Investment;
    public double Enthusiasm;
    public int ID;
    public double PollPCT1;
    public double PollPCT0;
    public double EVPCT1;
    public double EVPCT0;
    public double Quality1;
    public double Quality0;
    public double Investment1;
    public double Investment0;
    public double Enthusiasm1;
    public double Enthusiasm0;
}
public class Party
{
    public int PartyID;
    public string Name;
    public string Abbrv;
    public string People;
    public string Color;
}
public static class GENERAL
 {
    public static string MapFilePath = @"C:\Users\Pin\Desktop\Unity Election Simulator\Small_Election_Sim\Assets\Datas\Map_Example.txt";
    public static string CandidateFilePath = @"C:\Users\Pin\Desktop\Unity Election Simulator\Small_Election_Sim\Assets\Datas\Candidate_Example.txt";
    public static string NationName;
    public static int MapX;
    public static int MapY;
    public static int Layers;
    public static List<string> LayerList = new List<string>();
    public static int L1;
    public static int L2;
    public static int CandidateQTY;
    public static int PartyQTY; //Excluding "Other"
 }


