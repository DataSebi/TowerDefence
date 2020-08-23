using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSocket : MonoBehaviour
{
    public GameObject turret;
    private GameManager gameManger;
    
    [HideInInspector] public int price;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
        price = 5;
    }
    private void OnMouseDown()
    {
        gameManger.SelectBuildSocket(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
