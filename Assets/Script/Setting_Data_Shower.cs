using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_Data_Shower : MonoBehaviour
{
    public TMPro.TMP_InputField StartTime;
    public TMPro.TMP_InputField VarietySeed;
    public TMPro.TMP_InputField ElectionSpeed;
    public TMPro.TMP_Text MapOption;
    public Setting_SetupData SD;

    private void Start()
    {
        if (Setting_SetupData.FIRSTLVs.Count == 0) SD.GameOpenSetup();
        else
        {
            MapOptionSet();
            //VarietySeedSet();
            //StartTimeSet();
            //ElectionSpeedSet();
        }
    }
    public void VarietySeedSet()
    {

    }
    public void StartTimeSet()
    {

    }
    public void ElectionSpeedSet()
    {

    }
    public void MapOptionSet()
    {
        MapOption.text = GENERAL.MapX.ToString() + "x" + GENERAL.MapY.ToString();
    }
}
