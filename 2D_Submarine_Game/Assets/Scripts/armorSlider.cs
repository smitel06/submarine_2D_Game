using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class armorSlider : MonoBehaviour
{
    
    //armor values
    public GameObject player;
    float armor;
    float maxArmor;
    float percentageFloat;
    int percentage;
    Text percentageText;

    //retrieve and set armor
    
    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //keep updating armor values
        maxArmor = player.GetComponent<PlayerController>().maxArmor;
        armor = player.GetComponent<PlayerController>().armor;
        //get percentage
        percentageFloat = (100f / maxArmor) * armor;
        percentage = (int)percentageFloat;
        //set on screen
        percentageText.text = percentage + "%";
    }
}
