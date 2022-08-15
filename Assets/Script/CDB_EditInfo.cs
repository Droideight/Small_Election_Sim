using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CDB_EditInfo : MonoBehaviour
{
    public GameObject ZeroIB;
    public GameObject OneIB;
    public GameObject TwoIB;
    public GameObject ThreeIB;
    public GameObject FourIB;
    public GameObject FiveIB;
    public GameObject SixIB;
    public GameObject SevenIB;
    public GameObject EightIB;
    public GameObject NineIB;
    public GameObject ZeroEF;
    public GameObject OneEF;
    public GameObject TwoEF;
    public GameObject ThreeEF;
    public GameObject FourEF;
    public GameObject FiveEF;
    public GameObject SixEF;
    public GameObject SevenEF;
    public GameObject EightEF;
    public GameObject NineEF;
    public GameObject ZeroTX;
    public GameObject OneTX;
    public GameObject TwoTX;
    public GameObject ThreeTX;
    public GameObject FourTX;
    public GameObject FiveTX;
    public GameObject SixTX;    
    public GameObject SevenTX;  
    public GameObject EightTX;
    public GameObject NineTX;
    public Setting_SetupData SD;
    public static int CDB_LaneEdit = 0;
    public CDB_ScaleChange CSC;

    public void EditInfo(int which) 
    {
        switch (which) 
        {
            case 0:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(ZeroEF.name)];
                ZeroEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                ZeroIB.SetActive(true);
                break;
            case 1:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(OneEF.name)];
                OneEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                TMPro.TMP_Dropdown DDIQ = OneIB.GetComponent<TMPro.TMP_Dropdown>();
                List<string> DDIQop = new List<string>();
                DDIQ.ClearOptions();
                DDIQop.Add("--");
                foreach (Party A in Setting_SetupData.Parties)
                {
                    DDIQop.Add(A.Abbrv);
                }
                DDIQ.AddOptions(DDIQop);
                OneIB.SetActive(true);
                break;
            case 2:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(TwoEF.name)];
                break;
            case 3:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(ThreeEF.name)];
                ThreeEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                TMPro.TMP_Dropdown DDIQ3 = ThreeIB.GetComponent<TMPro.TMP_Dropdown>();
                List<string> DDIQ3op = new List<string>();
                DDIQ3.ClearOptions();
                DDIQ3op.Add("--");
                foreach (FIRSTLV A in Setting_SetupData.FIRSTLVs)
                {
                    DDIQ3op.Add(A.abbrv);
                }
                DDIQ3.AddOptions(DDIQ3op);
                ThreeIB.SetActive(true);
                break;
            case 4:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(FourEF.name)];
                FourEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                TMPro.TMP_Dropdown DDIQ4 = FourIB.GetComponent<TMPro.TMP_Dropdown>();
                List<string> DDIQ4op = new List<string>();
                DDIQ4.ClearOptions();
                DDIQ4op.Add("--");
                foreach (SECLV A in Setting_SetupData.SECONDLVs)
                {
                    if (Setting_SetupData.FIRSTLVs[A.FIRSTLV].abbrv == ThreeEF.GetComponent<TMPro.TextMeshProUGUI>().text) DDIQ4op.Add(A.Name);
                }
                DDIQ4.AddOptions(DDIQ4op);
                FourIB.SetActive(true);
                break;
            case 5:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(FiveEF.name)];
                FiveEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                FiveIB.SetActive(true);
                break;
            case 6:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(SixEF.name)];
                SixEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                SixIB.SetActive(true);
                break;
            case 7:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(SevenEF.name)];
                SevenEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                SevenIB.SetActive(true);
                break;
            case 8:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(EightEF.name)];
                EightEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                EightIB.SetActive(true);
                break;
            case 9:
                CDB_LaneEdit = CDB_ScaleChange.CandidateIDinQuestion[Convert.ToInt32(NineEF.name)];
                NineEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                NineIB.SetActive(true);
                break;
            default: break;
        }
    }
    public void ChangeInfo(int which)
    {
        switch (which)
        {
            case 0:
                ZeroEF.GetComponent<TMPro.TextMeshProUGUI>().text = ZeroTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                ZeroIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].Name = ZeroTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                break;
            case 1:
                OneEF.GetComponent<TMPro.TextMeshProUGUI>().text = OneTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                OneIB.SetActive(false);
                List<string> temp1 = new List<string>();
                foreach (Party A in Setting_SetupData.Parties)
                {
                    temp1.Add(A.Abbrv);
                }
                Setting_SetupData.Candidates[CDB_LaneEdit].PartyID = temp1.IndexOf(OneTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 2: break;
            case 3:
                ThreeEF.GetComponent<TMPro.TextMeshProUGUI>().text = ThreeTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FourEF.GetComponent<TMPro.TextMeshProUGUI>().text = "--";
                ThreeIB.SetActive(false);
                List<string> temp3 = new List<string>();
                foreach (FIRSTLV A in Setting_SetupData.FIRSTLVs)
                {
                    temp3.Add(A.abbrv);
                }
                Setting_SetupData.Candidates[CDB_LaneEdit].FLayer = temp3.IndexOf(ThreeTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 4:
                FourEF.GetComponent<TMPro.TextMeshProUGUI>().text = FourTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FourIB.SetActive(false);
                List<string> temp4 = new List<string>();
                List<string> tempX = new List<string>();
                foreach (FIRSTLV A in Setting_SetupData.FIRSTLVs)
                {
                    tempX.Add(A.abbrv);
                }
                foreach (SECLV B in Setting_SetupData.SECONDLVs)
                {
                    if (B.FIRSTLV == tempX.IndexOf(ThreeEF.GetComponent<TMPro.TextMeshProUGUI>().text))
                    {
                        temp4.Add(B.Name);
                    }
                }
                Setting_SetupData.Candidates[CDB_LaneEdit].SLayer = temp4.IndexOf(FourTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 5:
                FiveEF.GetComponent<TMPro.TextMeshProUGUI>().text = FiveTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FiveIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].PollPCT = Convert.ToDouble(FiveTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break; 
            case 6:
                SixEF.GetComponent<TMPro.TextMeshProUGUI>().text = SixTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                SixIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].EVPCT = Convert.ToDouble(SixTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 7:
                SevenEF.GetComponent<TMPro.TextMeshProUGUI>().text = SevenTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                SevenIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].Quality = Convert.ToDouble(SevenTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 8:
                EightEF.GetComponent<TMPro.TextMeshProUGUI>().text = EightTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                EightIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].Investment = Convert.ToDouble(EightTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            case 9:
                NineEF.GetComponent<TMPro.TextMeshProUGUI>().text = NineTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                NineIB.SetActive(false);
                Setting_SetupData.Candidates[CDB_LaneEdit].Enthusiasm = Convert.ToDouble(NineTX.GetComponent<TMPro.TextMeshProUGUI>().text);
                break;
            default: break;
        }
    }
    public void AddNewCandidateFromCDBBtn() 
    {
        if (CDB_ScaleChange.viewscale == "National") 
        {
            AddCandidate("Pin Yang", 0, 0, CDB_ScaleChange.viewFLV, CDB_ScaleChange.viewSLV, 0.00, 0.00, 50.00, 50.00, 50.00);
        }
        else AddCandidate("Pin Yang", 0, (GENERAL.LayerList.IndexOf(CDB_ScaleChange.viewscale))+1, CDB_ScaleChange.viewFLV, CDB_ScaleChange.viewSLV, 0.00,0.00,50.00,50.00,50.00);
        if (CDB_ScaleChange.viewscale == "National") { CSC.LoadL0Candidate(); }
        else if (CDB_ScaleChange.viewscale == GENERAL.LayerList[0]) { CSC.LoadL1Candidate(CDB_ScaleChange.viewFLV); }
        else if (CDB_ScaleChange.viewscale == GENERAL.LayerList[1]) { CSC.LoadL2Candidate(CDB_ScaleChange.viewSLV, CDB_ScaleChange.viewFLV); }
    }
    public void AddCandidate(string name, int partyID, int layer, int Flayer, int Slayer, double PollPCT,
        double EVPCT, double Quality, double Investment, double Enthusiasm) 
    {
        Candidate A = new Candidate();
        A.Name = name;
        A.PartyID = partyID;
        A.Layer = layer;
        A.FLayer = Flayer;
        A.SLayer = Slayer;
        A.PollPCT = PollPCT;
        A.EVPCT = EVPCT;
        A.Quality = Quality;
        A.Investment = Investment;
        A.Enthusiasm = Enthusiasm;
        Setting_SetupData.Candidates.Add(A);
    }

    private void Start()
    {
        ZeroIB.SetActive(false);
        OneIB.SetActive(false);
        ThreeIB.SetActive(false);
        FourIB.SetActive(false);
        FiveIB.SetActive(false);
        SixIB.SetActive(false);
        SevenIB.SetActive(false);
        EightIB.SetActive(false);
        NineIB.SetActive(false);
    }
}
