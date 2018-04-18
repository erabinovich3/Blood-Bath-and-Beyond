using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplaySelectedMom : MonoBehaviour
{

    public GameObject[] dismoms;

    // Use this for initialization
    void Start()
    {
        GameObject temp = GameObject.Find("MomSelect");
        SelectMom momScript = temp.GetComponent<SelectMom>();
        int sM = momScript.momNumber;
        dismoms[sM].SetActive(true);

        Destroy(temp);
    }

    // Update is called once per frame
    void Update()
    {

    }
}