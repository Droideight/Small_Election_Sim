using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDB_ScaleChange : MonoBehaviour
{
    public string viewscale;
    public int viewFLV;
    public int viewSLV;
    public GameObject Label;
    public GameObject ScaleText;
    public GameObject FLVText;
    public GameObject SLVText;
    public GameObject EnableOptions;
    public GameObject Me;
    public GameObject FirstDropdown;
    public GameObject SecondDropdown; 
    public GameObject ThirdDropdown;
    List<string> m_DropOptions = new List<string> { "Choose One" };
    public static List<Candidate> ShowData = new List<Candidate>();
    //public Setting_SetupData SP;
    public CDB_BuildUI SD;

    private void Update()
    {
        if (viewscale != "National" && viewscale != GENERAL.LayerList[0] && viewscale != GENERAL.LayerList[1])
        {
            AddOptions(0);
            setViewScale("National");
        }
    }
    public void setViewScaleByChoose()
    {
        setViewScale(Label.GetComponent<TMPro.TextMeshProUGUI>().text);
        TMPro.TMP_Dropdown option = EnableOptions.GetComponent<TMPro.TMP_Dropdown>();
        TMPro.TMP_Dropdown third = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
        string C1 = GENERAL.LayerList[0];
        string C2 = GENERAL.LayerList[1];
        if (viewscale == "National") { option.interactable = false; third.interactable = false; LoadL0Candidate(); }
        else if (viewscale == C1) { option.interactable = true; third.interactable = false; AddOptions(1); }
        else if (viewscale == C2) { option.interactable = true; third.interactable = false; AddOptions(1); }
    }
    public void setViewFLVByChoose()
    {
        setViewScale(ScaleText.GetComponent<TMPro.TextMeshProUGUI>().text);
        foreach (FIRSTLV entity in Setting_SetupData.FIRSTLVs) 
        { 
        if (entity.Name == Label.GetComponent<TMPro.TextMeshProUGUI>().text) 
            {
                setViewFLV(Setting_SetupData.FIRSTLVs.IndexOf(entity));
            }
        }
        TMPro.TMP_Dropdown option = EnableOptions.GetComponent<TMPro.TMP_Dropdown>();
        TMPro.TMP_Dropdown third = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
        string C1 = GENERAL.LayerList[0];
        string C2 = GENERAL.LayerList[1];
        if (viewscale == "National") { option.interactable = false; }
        else if (viewscale == C1) { option.interactable = false; LoadL1Candidate(viewFLV); }
        else if (viewscale == C2) { option.interactable = true; AddOptions(2);}
    }
    public void setViewSLVByChoose()
    {
        foreach (SECLV entity in Setting_SetupData.SECONDLVs)
        {
            if (entity.Name == Label.GetComponent<TMPro.TextMeshProUGUI>().text)
            {
                //if (entity.FIRSTLV == SetupData.FIRSTLVs[viewFLV].abbrv) 
                setViewSLV(Setting_SetupData.SECONDLVs.IndexOf(entity));
                LoadL2Candidate(viewSLV);
            }
        }
    }
    public void setViewScale(string scale)
    {
        viewscale = scale;
    }
    public void setViewFLV(int FLVID)
    {
        viewFLV = FLVID;
    }
    public void setViewSLV(int SLVID)
    {
        viewSLV = SLVID;
    }
    public void AddOptions(int which)
    {
        switch (which) 
        {
            case 0:
                m_DropOptions.Clear();
                m_DropOptions.Add("CHOOSE ONE");
                m_DropOptions.Add("National");
                m_DropOptions.Add(GENERAL.LayerList[0]);
                m_DropOptions.Add(GENERAL.LayerList[1]);
                TMPro.TMP_Dropdown Myself = FirstDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Myself.ClearOptions();
                Myself.AddOptions(m_DropOptions);
                break;
            case 1:
                m_DropOptions.Clear();
                m_DropOptions.Add("CHOOSE ONE");
                foreach (FIRSTLV target in Setting_SetupData.FIRSTLVs) { m_DropOptions.Add(target.Name); }
                TMPro.TMP_Dropdown Twoself = SecondDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Twoself.ClearOptions();
                Twoself.AddOptions(m_DropOptions);
                break;
            case 2:
                m_DropOptions.Clear();
                m_DropOptions.Add("CHOOSE ONE");
                foreach (SECLV target in Setting_SetupData.SECONDLVs) 
                { 
                    if (target.FIRSTLV == Setting_SetupData.FIRSTLVs[viewFLV].abbrv){ m_DropOptions.Add(target.Name); }
                }
                TMPro.TMP_Dropdown Thirdself = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Thirdself.ClearOptions();
                Thirdself.AddOptions(m_DropOptions);
                break;
            default: 
                break;
        }

    }
    public void LoadL0Candidate() { }
    public void LoadL1Candidate(int FLV) 
    {
        
    }
    public void LoadL2Candidate(int SLV) 
    {
        SD.DestroyDataLane();
        ShowData.Clear();
        foreach (Candidate people in Setting_SetupData.Candidates) 
        {
            if (people.SLayer == Setting_SetupData.SECONDLVs[SLV].Name) { ShowData.Add(people); }
        }
        SD.GenerateDataLane(ShowData.Count);
        SD.ShowLaneInfo(ShowData);
    }

}
