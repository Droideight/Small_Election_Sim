using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CDB_BuildUI : MonoBehaviour
{
    public GameObject DataLane;
    public GameObject Header;
    public GameObject Parent;
    public Component[] Temp;
    public Setting_SetupData SC;
    public CDB_EditInfo CEI;
    public CDB_ScaleChange CSC;
    public static List<GameObject> SpawnedLanes = new List<GameObject>();

    public void GenerateDataLane(int lanes)
    {
        for (int i = 1; i <= lanes; i++)
        {
            GameObject NewLane = Instantiate(DataLane, new Vector3(Header.transform.position.x, Header.transform.position.y, Header.transform.position.z), Quaternion.identity, Parent.transform);
            SpawnedLanes.Add(NewLane);
        }
    }
    public void DestroyDataLane()
    {
        foreach (GameObject Item in SpawnedLanes.ToList())
        {
            SpawnedLanes.Remove(Item);
            Destroy(Item);
        }
    }
    public void ShowLaneInfo(List<Candidate> listpassed)
    {
        if (listpassed.Count >0)
            {
            int count = 0;
            foreach (GameObject Lane in SpawnedLanes)
            {
                Transform LaneMade = Lane.transform;
                LaneMade.name = count.ToString();
                Transform DelBtn = LaneMade.GetChild(1);
                DelBtn.name = count.ToString();
                Transform Name = LaneMade.GetChild(2);
                Name.name = count.ToString();
                Transform Party = LaneMade.GetChild(4);
                Party.name = count.ToString();
                Transform Race = LaneMade.GetChild(6);
                Race.name = count.ToString();
                Transform FirstLayer = LaneMade.GetChild(8);
                FirstLayer.name = count.ToString();
                Transform SecondLayer = LaneMade.GetChild(10);
                SecondLayer.name = count.ToString();
                Transform PollPCT = LaneMade.GetChild(12);
                PollPCT.name = count.ToString();
                Transform EVPCT = LaneMade.GetChild(14);
                EVPCT.name = count.ToString();
                Transform Quality = LaneMade.GetChild(16);
                Quality.name = count.ToString();
                Transform Invest = LaneMade.GetChild(18);
                Invest.name = count.ToString();
                Transform Enthusiasm = LaneMade.GetChild(20);
                Enthusiasm.name = count.ToString();
                Name.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Name;
                Party.GetComponent<TMPro.TextMeshProUGUI>().text = Setting_SetupData.Parties[listpassed[count].PartyID].Abbrv.ToString();
                if (listpassed[count].Layer == 0) { Race.GetComponent<TMPro.TextMeshProUGUI>().text = "NAT."; }
                else { Race.GetComponent<TMPro.TextMeshProUGUI>().text = GENERAL.LayerList[listpassed[count].Layer - 1].ToString(); }
                FirstLayer.GetComponent<TMPro.TextMeshProUGUI>().text = Setting_SetupData.FIRSTLVs[listpassed[count].FLayer].abbrv;
                List<string> temp = new List<string>();
                temp.Clear();
                foreach (SECLV A in Setting_SetupData.SECONDLVs)
                {
                    if (A.FIRSTLV == listpassed[count].FLayer) temp.Add(A.Name);
                }
                SecondLayer.GetComponent<TMPro.TextMeshProUGUI>().text = temp[listpassed[count].SLayer];
                PollPCT.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].PollPCT.ToString();
                EVPCT.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].EVPCT.ToString();
                Quality.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Quality.ToString();
                Invest.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Investment.ToString();
                Enthusiasm.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Enthusiasm.ToString();
                count++;
            }
            count = 0;
        }
    }
    public void AddNewCandidateFromCDBBtn()
    {
        if (CDB_ScaleChange.viewscale == "National")
        {
            for (int i = 0; i <= Setting_SetupData.SECONDLVs.Count - 1; i++)
            {
                CEI.AddCandidate("Pin Yang", 0, 0 , Setting_SetupData.SECONDLVs[i].FIRSTLV, Setting_SetupData.SECONDLVs[i].SUBID , 0.00, 0.00, 50.00, 50.00, 50.00);
            }
        }
        else if (CDB_ScaleChange.viewscale == GENERAL.LayerList[0])
        {
            for (int i = 0; i <= Setting_SetupData.FIRSTLVs[CDB_ScaleChange.viewFLV].SECLV-1; i++)
            {
                CEI.AddCandidate("Pin Yang", 0, (GENERAL.LayerList.IndexOf(CDB_ScaleChange.viewscale)) + 1, CDB_ScaleChange.viewFLV, i, 0.00, 0.00, 50.00, 50.00, 50.00);
            }
        }
        else if (CDB_ScaleChange.viewscale == GENERAL.LayerList[1])
        {
            CEI.AddCandidate("Pin Yang", 0, (GENERAL.LayerList.IndexOf(CDB_ScaleChange.viewscale)) + 1, CDB_ScaleChange.viewFLV, CDB_ScaleChange.viewSLV, 0.00, 0.00, 50.00, 50.00, 50.00);
        }
        RefreshCandidatePanel();              
    }
    public void RefreshCandidatePanel()
    {
        List<Candidate> StringPassed = new List<Candidate>();
        if (CDB_ScaleChange.viewscale == "National") { StringPassed = CSC.LoadL0Candidate(); }
        if (CDB_ScaleChange.viewscale == GENERAL.LayerList[0]) { StringPassed = CSC.LoadL1Candidate(); }
        if (CDB_ScaleChange.viewscale == GENERAL.LayerList[1]) { StringPassed = CSC.LoadL2Candidate(); }
        DestroyDataLane();
        GenerateDataLane(StringPassed.Count);
        ShowLaneInfo(StringPassed);
    }
}
