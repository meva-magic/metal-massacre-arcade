using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    public List<TextMeshProUGUI> names;

    [SerializeField]
    public List<TextMeshProUGUI> scores;

    private string  publicLeaderboardKey = "1a24fba2377b252a8eecd72fd5cd0aef8825eb081b7173da194256d854e34d9d";

    void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => 
        {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text =  msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => 
        {
            //username.Substring(0, 9);
            GetLeaderboard();
        }));
    }
}
