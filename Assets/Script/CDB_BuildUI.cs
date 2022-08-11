using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CDB_BuildUI : MonoBehaviour
{
    public GameObject DataLane;
    public GameObject Header;
    public GameObject Parent;
    public Component[] Temp;
    public Setting_SetupData SC;
    public static List<GameObject> SpawnedLanes = new List<GameObject>();

    public void GenerateDataLane(int lanes)
    {
        for (int i = 1; i<= lanes; i++) 
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
                Transform Name = LaneMade.GetChild(0);
                Name.name = count.ToString();
                Transform Party = LaneMade.GetChild(2);
                Party.name = count.ToString();
                Transform Race = LaneMade.GetChild(4);
                Race.name = count.ToString();
                Transform FirstLayer = LaneMade.GetChild(6);
                FirstLayer.name = count.ToString();
                Transform SecondLayer = LaneMade.GetChild(8);
                SecondLayer.name = count.ToString();
                Transform PollPCT = LaneMade.GetChild(10);
                PollPCT.name = count.ToString();
                Transform EVPCT = LaneMade.GetChild(12);
                EVPCT.name = count.ToString();
                Transform Quality = LaneMade.GetChild(14);
                Quality.name = count.ToString();
                Transform Invest = LaneMade.GetChild(16);
                Invest.name = count.ToString();
                Transform Enthusiasm = LaneMade.GetChild(18);
                Enthusiasm.name = count.ToString();
                Name.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Name;
                Party.GetComponent<TMPro.TextMeshProUGUI>().text = Setting_SetupData.Parties[listpassed[count].PartyID].Abbrv.ToString();
                Race.GetComponent<TMPro.TextMeshProUGUI>().text = GENERAL.LayerList[listpassed[count].Layer-1].ToString(); 
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
}
