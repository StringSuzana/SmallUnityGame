using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StudentInfo
{
    public string studentName;
    public float totalExtraPoints;
    public float totalQuizesPlayTime;

    public StudentInfo(PlayerData player)
    {
        studentName = player.StudentInfo.studentName;
        totalExtraPoints = player.StudentInfo.totalExtraPoints;
        totalQuizesPlayTime = player.StudentInfo.totalQuizesPlayTime;
    }

    
}
