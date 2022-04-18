using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;


// Paul Kent Yochum
// Leaderboard Controller Script
// 4/17/2022

public class LeaderboardController : MonoBehaviour
{
    public InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 7;
    public Text[] Entries;


    private void Start()    // Authenticates the player
    {

        LootLockerSDKManager.StartGuestSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void ShowScores()    // Allows for desplay of scores
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for(int i =0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ".   " + scores[i].member_id + "     " +scores[i].score);
                }

                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }

    public void SubmitScore()    // Allows to manually submit score
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Failed");
            }
        });
    }
}
