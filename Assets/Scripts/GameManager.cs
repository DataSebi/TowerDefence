using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // ressources
    private BuildSocket currentBuildSocketSelected;

    public GameObject buildScreen;
    private Button buildButton;

    void Start()
    {
        buildButton = buildScreen.GetComponentInChildren<Button>();
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
        //build on currentSelectedTurretSocket
        Instantiate(currentBuildSocketSelected.turret, currentBuildSocketSelected.transform.position, currentBuildSocketSelected.transform.rotation);
        gameObject.SetActive(false);
        buildScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
