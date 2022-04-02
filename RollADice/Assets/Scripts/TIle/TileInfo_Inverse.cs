using System;
using UnityEngine;

    internal class TileInfo_Inverse : TileInfo
    {
    public override void TileEvent()
    {
        Debug.Log($"index of this tile : {index} , player will move inversed direction once");
        DicePlayManager.instance.direction = -1; 
    }

}

