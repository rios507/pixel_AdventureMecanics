using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI MissionText1;
    [SerializeField] int maxItemsCount;
    bool missionComplete1 = false;

    [SerializeField] TextMeshProUGUI MissionText2;
    [SerializeField] PlayerMovement player;

    [SerializeField] ColletionsController Colletion;

    int jumpsCount;
    [SerializeField] int maxJumpsCount;
    bool missionComplete2 = false;

    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject GameTimer;
    // Start is called before the first frame update
    void Start()
    {
        Colletion.ColletorCounter += mission_1;
    }

    // Update is called once per frame
    void Update()
    {
        mission_2();
        sistemOfMissions();
    }
    public void mission_1(int itemValue)
    {
        MissionText1.text = itemValue.ToString();
        if (itemValue >= maxItemsCount)
        {
            missionComplete1 = true;
            itemValue = maxItemsCount;
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
