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
                Transform Name = LaneMade.GetChild(0);
                Transform Party = LaneMade.GetChild(2);
                Transform Race = LaneMade.GetChild(4);
                Transform FirstLayer = LaneMade.GetChild(6);
                Transform SecondLayer = LaneMade.GetChild(8);
                Transform PollPCT = LaneMade.GetChild(10);
                Transform EVPCT = LaneMade.GetChild(12);
                Transform Quality = LaneMade.GetChild(14);
                Transform Invest = LaneMade.GetChild(16);
                Transform Enthusiasm = LaneMade.GetChild(18);
                Name.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Name;
                Party.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].PartyID.ToString();
                Race.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].Layer.ToString();
                FirstLayer.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].FLayer;
                SecondLayer.GetComponent<TMPro.TextMeshProUGUI>().text = listpassed[count].SLayer;
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
