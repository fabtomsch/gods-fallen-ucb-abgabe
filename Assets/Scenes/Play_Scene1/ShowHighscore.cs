using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHighscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore") && score != null)
        {
            int time = (int) PlayerPrefs.GetFloat("Highscore");
            if(time > 0)
            {
                score.SetText(time + " seconds");
            }
          
        }
    }
}
