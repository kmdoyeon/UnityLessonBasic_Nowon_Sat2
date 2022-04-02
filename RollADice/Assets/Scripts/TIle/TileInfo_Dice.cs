using System;
using UnityEngine;

    internal class TileInfo_Dice : TileInfo
    {
       

        public override void TileEvent()
        {
            Debug.Log($"index of this tile : {index} , increase dice num + 1");
            DicePlayManager.instance.diceNum++;
        }

}

