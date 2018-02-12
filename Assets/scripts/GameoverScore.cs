using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable
    ]
public class Medal
{
    public Sprite Image;
    public int MinimumPoints;
}

public class GameoverScore : MonoBehaviour {

    public Text Score;
    public Image Medal;
    public GameObject Record;

    public Medal[] Medals;
	// Use this for initialization
	void Start ()
    {
        RefreshPoints();
        RefreshMedal();

    }

    private int GetCurrentPoints()
    {
        return PlayerPrefs.GetInt("current_points", 0);
    }

    private void RefreshPoints()
    {
        // current amount of points
        var points = GetCurrentPoints();
        // change text of score
        Score.text = points.ToString() + " points!";
    }

    private void RefreshMedal()
    {
        // current amount of points
        var points = GetCurrentPoints();

        Medal.sprite = Medals
            .Where(medal => medal.MinimumPoints <= points)
            .OrderBy(medal => medal.MinimumPoints)
            .Last()
            .Image;
    }

    private void RefreshRecord()
    {
        // current amount of points
        var currentPoints = GetCurrentPoints();
        var recordPoints = PlayerPrefs.GetInt("record_points", 0);

        bool isRecord = (currentPoints > recordPoints);

        if (isRecord)
        {
            PlayerPrefs.SetInt("record_points", currentPoints);
            Record.SetActive(isRecord);
            Debug.Log("current: " + currentPoints + " / " + "record: " + recordPoints);
        } 



    }

}
