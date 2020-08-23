using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSocket : MonoBehaviour
{
    public GameObject turret;
    private GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
