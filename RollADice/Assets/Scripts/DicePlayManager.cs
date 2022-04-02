using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DicePlayManager : MonoBehaviour 
{
    public static DicePlayManager instance;

    private int currentTileInex; // 현재 칸 (위치) 인덱스 
    private int _diceNum; // 남은 주사위 총 갯수 
    
    public int diceNum
    {
        set
        {
            if (value >= 0) // 남은 주사위 갯수를 0 이상만 셋 가능 
            {
                _diceNum = value;  
                diceText.text = _diceNum.ToString(); // Text 업데이트 
            }

        }

        get
        {
            return _diceNum;
        }
    }
    public Text diceText; // 남은 주사위 갯수 텍스트 UI
    public int diceNumInit; // 주사위 초기 값 

    private int _goldenDiceNum; // 황금 주사위 남은 갯수 
    
    public int goldenDiceNum
    {
        set
        {
            if (value >= 0)
            {
                _goldenDiceNum = value;
                goldenDiceNumText.text = _goldenDiceNum.ToString();
            }

        }

        get
        {
            return _goldenDiceNum;
        }
    }
    public Text goldenDiceNumText;
    public int goldenDiceNumInit;
    
    private int _starScore;
    public int starScore
    {
        set
        {
            if (value >= 0)
            {
                _starScore = value;
                starScoreText.text = _starScore.ToString();
            }

        }

        get
        {
            return _starScore;
        }
    }
    public Text starScoreText;

    // public int direction = 1; // 1 : forward, -1 : backward
    public int _direction;
    public int direction
    {
        set
        {
            _direction = value;
            if(_direction > 0)
                inversePanel.SetActive(false);
            else 
                inversePanel.SetActive(true);
        }
        get
        {
            return _direction;
        }
    }
    public GameObject inversePanel;
    
    public List<Transform> mapTiles;

    public Coroutine animationCoroutine = null;

    private void Awake()
    {
        instance = this;
        diceNum = diceNumInit;
        goldenDiceNum = goldenDiceNumInit;
        starScore = 0;
    }

    public void RollADice()
    {
        if (diceNum < 1) return;
        if (animationCoroutine != null) return;

        diceNum--;
        int diceValue = Random.Range(1, 7);
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer)); 

    }

    public void RollAGoldenDice(int diceValue)
    {
        if (goldenDiceNum < 1) return;
        if (animationCoroutine != null) return;

        goldenDiceNum--;
        animationCoroutine = StartCoroutine(DiceAnimationUI.instance.E_DiceAnimation(diceValue, this, MovePlayer));
        
    }
    
    private void MovePlayer(int diceValue)
    {
        int previousTileIndex = currentTileInex;
        currentTileInex += diceValue * direction;

        CheckPlayerPassedStarTile(previousTileIndex, currentTileInex );
         

        if(currentTileInex >= mapTiles.Count)
            currentTileInex -= mapTiles.Count;

        Debug.Log($"move to {currentTileInex}, {direction}");
        Player.instance.Move(GetTilePosition(currentTileInex));
        direction = 1;

        mapTiles[currentTileInex].GetComponent<TileInfo>().TileEvent();
        
    }

    private void CheckPlayerPassedStarTile(int previoudindex, int currentindex)
    {
        /* TileInfo_Star tmpStarTile = null;
        for (int i = previoudindex + 1; i <= currentindex; i++)
        {
            bool isPassed = mapTiles[i].TryGetComponent(out tmpStarTile); // component 가져오는 걸 시도, 실패하면 false
            if (isPassed)
                starScore += tmpStarTile.starValue;
        }*/

        for (int i = previoudindex + 1; i <= currentindex; i++)
        {
            int tmpIndex = i;
            if (tmpIndex >= mapTiles.Count)
                tmpIndex -= mapTiles.Count;

            if (mapTiles[tmpIndex].TryGetComponent(out TileInfo_Star tmpStarTile))  // <= 위의 코드를 줄인 것 
                starScore += tmpStarTile.starValue;
        }
    }

    private Vector3 GetTilePosition(int tileIndex)
    {
        return mapTiles[tileIndex].position; 
    }
}

