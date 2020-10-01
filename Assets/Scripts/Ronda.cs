
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Ronda : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _tRound;
    public int gm;

    
    private Animator round;

    void Start()
    {
       round =  GetComponent<Animator>();
        activar();
       
    }

   
    void Update()
    {
        
    }


    public void activar()
    {
        gm++;
        updateoDePunto();
        round.SetTrigger("lol");
        if(gm > PlayerPrefs.GetInt("Round"))
        {
            PlayerPrefs.SetInt("Round", gm);
        }
        
     
    }

    public void updateoDePunto()
    {

        switch (gm)
        {
            case 1:
                _tRound.text = "Round 1";
                break;
            case 2:
                _tRound.text = "Round 2";
                break;
            case 3:
                _tRound.text = "Round 3";
                break;
            case 4:
                _tRound.text = "Round 4";
                break;
            case 5:
                _tRound.text = "Round 5";
                break;
            case 6:
                _tRound.text = "Round 6";
                break;
            case 7:
                _tRound.text = "Round 7";
                break;
            case 8:
                _tRound.text = "Round 8";
                break;
            case 9:
                _tRound.text = "Round 9";
                break;
            case 10:
                _tRound.text = "Round 10";
                break;
            default:
                _tRound.text = "IMPOSSIBLE MODE!";
                break;
        }
    }

 
}
