using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour {

    int Points = 0;



	// Use this for initialization
	void Start () {

        SavePoints();
        RefreshText();
	}
	
    public void IncrementPoints()
    {
        Points++;
        SavePoints();
        RefreshText();
    }

    void SavePoints()
    {
        PlayerPrefs.SetInt("current_points", Points);
    }

    public void RefreshText()
    {
        GetComponent<Text>().text = Points.ToString() + " pts";
    }
}
