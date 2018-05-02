using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySelectedMom : MonoBehaviour
{

    public GameObject[] dismoms;

    // Use this for initialization
    void Awake()
    {
        GameObject temp = GameObject.Find("MomSelect");
        SelectMom momScript = temp.GetComponent<SelectMom>();
        int sM = momScript.momNumber;
        GameController.controller.curMom = sM;
        dismoms[sM].SetActive(true);

        Destroy(temp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}