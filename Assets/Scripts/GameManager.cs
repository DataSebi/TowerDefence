using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int gold;
    private BuildSocket currentBuildSocketSelected;

    public TextMeshProUGUI goldText;
    public GameObject buildScreen;
    private Button buildButton;

    void Start()
    {
        buildButton = buildScreen.GetComponentInChildren<Button>();
        gold = 0;
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
        //active Build Screen
        currentBuildSocketSelected = turretSocket;
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
