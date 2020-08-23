using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSocket : MonoBehaviour
{
    public GameObject turret;
    public GameObject buildScreen;
    private Button buildButton;

    // Start is called before the first frame update
    void Start()
    {
        buildButton = buildScreen.GetComponentInChildren<Button>();
        buildButton.onClick.AddListener(Build);
    }
    private void OnMouseDown()
    {
        buildScreen.SetActive(true);
    }

    public void Build()
    {
        Instantiate(turret, transform.position, transform.rotation);
        gameObject.SetActive(false);
        buildScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
