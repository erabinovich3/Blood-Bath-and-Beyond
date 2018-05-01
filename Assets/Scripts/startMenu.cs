using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

    private RawImage instrs;
    private Button instrs_button;
    private Button back;
    private Button credits_button;
    private Image creditsBG;
    private Text credits;

	// Use this for initialization
	void Start () {
        instrs = GameObject.Find("RawImage").GetComponent<RawImage>();
        instrs.enabled = false;

        instrs_button = GameObject.Find("Instrs").GetComponent<Button>();
        instrs_button.onClick.AddListener(ShowInstructions);

        /*creditsBG = GameObject.Find("Image").GetComponent<Image>();
        if (creditsBG == null) { Debug.LogError("No background"); }
        creditsBG.enabled = false;
        credits = GameObject.Find("Credits").GetComponent<Text>();
        credits.enabled = false;*/

        credits_button = GameObject.Find("Credits").GetComponent<Button>();
        credits_button.onClick.AddListener(ShowCredits);

        back = GameObject.Find("Back").GetComponent<Button>();
        back.onClick.AddListener(GoBack);
        back.gameObject.SetActive(false);
    }

    public void ShowInstructions() {
        instrs.enabled = true;
        back.gameObject.SetActive(true);
    }

    public void ShowCredits() {
        SceneManager.LoadScene("Credits");
        /*creditsBG.enabled = true;
        credits.enabled = true;
        back.gameObject.SetActive(true);*/
    }

    public void GoBack() {
        instrs.enabled = false;
        //creditsBG.enabled = false;
        //credits.enabled = false;
        back.gameObject.SetActive(false);
    }
}
