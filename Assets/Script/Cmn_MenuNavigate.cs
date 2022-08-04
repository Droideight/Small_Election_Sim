using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cmn_MenuNavigate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string scenename = "Menu";
    public void switchscene (string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
