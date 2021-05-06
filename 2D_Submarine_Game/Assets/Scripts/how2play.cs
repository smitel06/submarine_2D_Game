using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class how2play : MonoBehaviour
{
    public GameObject howToPlayScreen;
    public GameObject menuScreen;
    public Button returnButton;
    // Start is called before the first frame update
    void Start()
    {
        Button returnButtonObj = returnButton.GetComponent<Button>();
        returnButton.onClick.AddListener(returnOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void returnOnClick()
    {
        howToPlayScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

}
