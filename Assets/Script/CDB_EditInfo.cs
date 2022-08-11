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
            case 2: break;
            case 3:
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
                FiveEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                FiveIB.SetActive(true);
                break;
            case 6:
                SixEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                SixIB.SetActive(true);
                break;
            case 7:
                SevenEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                SevenIB.SetActive(true);
                break;
            case 8:
                EightEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                EightIB.SetActive(true);
                break;
            case 9:
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
                break;
            case 2: break;
            case 3:
                ThreeEF.GetComponent<TMPro.TextMeshProUGUI>().text = ThreeTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FourEF.GetComponent<TMPro.TextMeshProUGUI>().text = "--";
                ThreeIB.SetActive(false);
                break;
            case 4:
                FourEF.GetComponent<TMPro.TextMeshProUGUI>().text = FourTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FourIB.SetActive(false);
                break;
            case 5:
                FiveEF.GetComponent<TMPro.TextMeshProUGUI>().text = FiveTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                FiveIB.SetActive(false);
                break; 
            case 6:
                SixEF.GetComponent<TMPro.TextMeshProUGUI>().text = SixTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                SixIB.SetActive(false);
                break;
            case 7:
                SevenEF.GetComponent<TMPro.TextMeshProUGUI>().text = SevenTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                SevenIB.SetActive(false);
                break;
            case 8:
                EightEF.GetComponent<TMPro.TextMeshProUGUI>().text = EightTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                EightIB.SetActive(false);
                break;
            case 9:
                NineEF.GetComponent<TMPro.TextMeshProUGUI>().text = NineTX.GetComponent<TMPro.TextMeshProUGUI>().text;
                NineIB.SetActive(false);
                break;
            default: break;
        }
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
