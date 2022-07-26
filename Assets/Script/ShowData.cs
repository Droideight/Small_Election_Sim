using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowData : MonoBehaviour
{
    public GameObject DataLane;
    public GameObject Header;
    public GameObject Parent;
    public Component[] Temp;
    public SetupData SC;
    List<GameObject> SpawnedLanes;

    public void GenerateDataLane(int lanes)
    {
        for (int i = 1; i<= lanes; i++) 
        {
            GameObject NewLane = Instantiate(DataLane, new Vector3(Header.transform.position.x, Header.transform.position.y, Header.transform.position.z), Quaternion.identity, Parent.transform);
            NewLane.name = "Lane" + i;
            Transform LaneMade = NewLane.transform;
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

            //Name.GetComponent<TMPro.TextMeshProUGUI>().text = SC.SECONDLVs[0].Name;
        }
    }
}
