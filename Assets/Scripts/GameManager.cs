using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int ressources;
    private BuildSocket currentBuildSocketSelected;

    public TextMeshProUGUI ressourceText;
    public GameObject buildScreen;
    private Button buildButton;

    void Start()
    {
        buildButton = buildScreen.GetComponentInChildren<Button>();
        ressources = 0;
        StartCoroutine(AddResources());
    }

    private IEnumerator AddResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            ressources += 1;
            ressourceText.text = "Ressources: " + ressources;
            Debug.Log(ressources);
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
        if (currentBuildSocketSelected.price <= ressources)
        {
            Instantiate(currentBuildSocketSelected.turret, currentBuildSocketSelected.transform.position, currentBuildSocketSelected.transform.rotation);
            //gameObject.SetActive(false);
            buildScreen.SetActive(false);
            ressources -= currentBuildSocketSelected.price;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
