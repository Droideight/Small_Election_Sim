using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowData : MonoBehaviour
{
    public GameObject DataLane;
    public GameObject Header;
    public GameObject Parent;
    public Component[] Temp;
    List<GameObject> SpawnedLanes;

    public void GenerateDataLane(int lanes)
    {
        for (int i = 1; i<= lanes; i++) 
        {
            GameObject NewLane = (GameObject)Instantiate(DataLane, new Vector3(Header.transform.position.x, Header.transform.position.y, Header.transform.position.z), Quaternion.identity, Parent.transform);
            SpawnedLanes.Add(NewLane);
        }
    }
    public void FillData(int lanes)
    {
        for (int i = 1; i <= lanes; i++)
        {
            Temp = SpawnedLanes[i-1].GetComponentsInChildren<Transform>();
        }
    }
}
