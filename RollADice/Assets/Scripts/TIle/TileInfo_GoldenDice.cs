using System;
using UnityEngine;

    internal class TileInfo_GoldenDice : TileInfo
    {
        public override void TileEvent()
        {
            Debug.Log($"index of this tile : {index} , increase godeln dice num + 1");
            DicePlayManager.instance.goldenDiceNum++;
        }

}

