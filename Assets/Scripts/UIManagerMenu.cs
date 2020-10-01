using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _HGscore;
    [SerializeField]
    private TMP_Text _Round;
  
    void Start()
    {
        _HGscore.text = PlayerPrefs.GetInt("HighScore").ToString();
        _Round.text = PlayerPrefs.GetInt("Round").ToString();
    }

   
    void Update()
    {
        
    }
}
