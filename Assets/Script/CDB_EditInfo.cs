using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void EditInfo(int which) 
    {
        switch (which) 
        {
            case 0:
                ZeroEF.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                ZeroIB.SetActive(true);
                break;
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
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
                break;
            case 1: break;
            case 2: break;
            case 3: break;
            case 4: break;
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
        FiveIB.SetActive(false);
        SixIB.SetActive(false);
        SevenIB.SetActive(false);
        EightIB.SetActive(false);
        NineIB.SetActive(false);
    }
}
