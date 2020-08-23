using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int gold;
    private int health;
    private BuildSocket currentBuildSocketSelected;

    public TextMeshProUGUI goldText;
    public TextMeshProUGUI healthText;
    public GameObject buildScreen;
    private Button buildButton;

    void Start()
    {
        buildButton = buildScreen.GetComponentInChildren<Button>();
        gold = 0;
        health = 3;
        healthText.text = "Health: " + health;
        StartCoroutine(AddGold());
    }

    private IEnumerator AddGold()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            gold += 1;
            goldText.text = "Gold: " + gold;
        }
    }

    public void SelectBuildSocket(BuildSocket turretSocket)
    {
        if (currentBuildSocketSelected != null)
        {
            currentBuildSocketSelected.selectMarker.SetActive(false);
        }
        //active Build Screen
        currentBuildSocketSelected = turretSocket;
        currentBuildSocketSelected.selectMarker.SetActive(true);
        buildScreen.SetActive(true);
        buildButton.onClick.AddListener(BuildTurret);
    }

    public void BuildTurret()
    {
        if (currentBuildSocketSelected.price <= gold)
        {
            Instantiate(currentBuildSocketSelected.turret, currentBuildSocketSelected.transform.position, currentBuildSocketSelected.transform.rotation);
            //gameObject.SetActive(false);
            buildScreen.SetActive(false);
            gold -= currentBuildSocketSelected.price;
            goldText.text = "Gold: " + gold;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
