using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


[CreateAssetMenu(fileName = "World", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Board Dimensions")]
    public int widht;
    public int height;

    [Header("Starting Tiles")]
    public TileType[] boardLayout;

    [Header("Availabel Dots")]
    public GameObject[] dots;

    [Header("Score Goals")]
    public int[] scoreGoals;

    [Header("End Game Requiments")]
    public EndGameRequirements endGameRequirements;
    public BlankGoal[] levelGoals;
}
