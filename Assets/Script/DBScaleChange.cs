using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBScaleChange : MonoBehaviour
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
    public SetupData Script1;

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
        Debug.Log(viewscale);
        TMPro.TMP_Dropdown option = EnableOptions.GetComponent<TMPro.TMP_Dropdown>();
        TMPro.TMP_Dropdown third = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
        string C1 = GENERAL.LayerList[0];
        string C2 = GENERAL.LayerList[1];
        if (viewscale == "National") { option.interactable = false; third.interactable = false; }
            else if (viewscale == C1) { option.interactable = true; third.interactable = false; AddOptions(1); }
        else if (viewscale == C2) { option.interactable = true; third.interactable = false; AddOptions(1); }
    }
    public void setViewFLVByChoose()
    {
        //Label.GetComponent<TMPro.TextMeshProUGUI>().text
        setViewScale(ScaleText.GetComponent<TMPro.TextMeshProUGUI>().text);
        setViewFLV(0);
        Debug.Log(viewscale);
        TMPro.TMP_Dropdown option = EnableOptions.GetComponent<TMPro.TMP_Dropdown>();
        TMPro.TMP_Dropdown third = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
        string C1 = GENERAL.LayerList[0];
        string C2 = GENERAL.LayerList[1];
        if (viewscale == "National") { option.interactable = false; Debug.Log("SEE1"); }
        else if (viewscale == C1) { option.interactable = false; Debug.Log("SEE2"); }
        else if (viewscale == C2) { option.interactable = true; AddOptions(2); Debug.Log("SEE3"); }
    }
    public void setViewSLVByChoose()
    {
        //Label.GetComponent<TMPro.TextMeshProUGUI>().text
        setViewScale(ScaleText.GetComponent<TMPro.TextMeshProUGUI>().text);
        setViewSLV(0);
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
                m_DropOptions.Add("National");
                m_DropOptions.Add(GENERAL.LayerList[0]);
                m_DropOptions.Add(GENERAL.LayerList[1]);
                TMPro.TMP_Dropdown Myself = FirstDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Myself.ClearOptions();
                Myself.AddOptions(m_DropOptions);
                break;
            case 1:
                m_DropOptions.Clear();
                foreach (FIRSTLV target in SetupData.FIRSTLVs) { m_DropOptions.Add(target.Name); }
                TMPro.TMP_Dropdown Twoself = SecondDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Twoself.ClearOptions();
                Twoself.AddOptions(m_DropOptions);
                break;
            case 2:
                m_DropOptions.Clear();
                foreach (SECLV target in SetupData.SECONDLVs) { m_DropOptions.Add(target.Name); }
                TMPro.TMP_Dropdown Thirdself = ThirdDropdown.GetComponent<TMPro.TMP_Dropdown>();
                Thirdself.ClearOptions();
                Thirdself.AddOptions(m_DropOptions);
                break;
            default: 
                break;
        }

    }
}
