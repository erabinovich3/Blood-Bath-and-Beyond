using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    public Button instrs_button;
    public Button back;
    public Button credits_button;

    private RawImage instrs;
    private Image creditsBG;
    private Text credits;

	// Use this for initialization
	void Start () {
        instrs = GameObject.Find("RawImage").GetComponent<RawImage>();
        instrs.enabled = false;
        
        instrs_button.onClick.AddListener(ShowInstructions);
        
        credits_button.onClick.AddListener(ShowCredits);
        
        back.onClick.AddListener(GoBack);
        back.gameObject.SetActive(false);
    }

    public void ShowInstructions() {
        instrs.enabled = true;
        back.gameObject.SetActive(true);
    }

    public void ShowCredits() {
        SceneManager.LoadScene("credits");
    }

    public void GoBack() {
        instrs.enabled = false;
        back.gameObject.SetActive(false);
    }
}
