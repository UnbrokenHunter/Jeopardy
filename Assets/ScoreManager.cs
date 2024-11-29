using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private Transform TeamContainer;

    [SerializeField] private GameObject TeamTemplate;

    private List<Team> Teams = new();
    private List<GameObject> TeamText = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void AddTeam(Team team)
    {
        Teams.Add(team);

        var teamObject = Instantiate(TeamTemplate, TeamContainer);
        teamObject.GetComponent<TeamScore>().InitScore(team);

        TeamText.Add(teamObject);
    }




}
