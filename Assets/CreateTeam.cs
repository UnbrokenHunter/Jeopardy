using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeam : MonoBehaviour
{
    public static void AddTeam()
    {
        ScoreManager.Instance.AddTeam(new Team());
    }
}
