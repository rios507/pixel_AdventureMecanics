using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MissionText1;
    int itemsCount;
    [SerializeField] int maxItemsCount;
    bool missionComplete1 = false;

    [SerializeField] TextMeshProUGUI MissionText2;
    [SerializeField] PlayerMovement player;
    int jumpsCount;
    [SerializeField] int maxJumpsCount;
    bool missionComplete2 = false;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject GameTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mission_1();
        mission_2();
        sistemOfMissions();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collection")
        {            
                itemsCount++;     
        }                 
    }
    public void mission_1()
    {
        MissionText1.text = itemsCount.ToString();
        if (itemsCount >= maxItemsCount)
        {
            missionComplete1 = true;
            itemsCount = maxItemsCount;
        }
    }
    public void mission_2()
    {
        MissionText2.text = jumpsCount.ToString();
        if (player.jumpActivated == true)
        {
            jumpsCount++;
        }
        if (jumpsCount >= maxJumpsCount)
        {
            missionComplete2 = true;
            jumpsCount = maxJumpsCount;
        }
    }
    public void sistemOfMissions()
    {
        if (missionComplete1 == true & missionComplete2 == true)
        {
            winPanel.SetActive(true);
            GameTimer.SetActive(false);
        }
    }
}
