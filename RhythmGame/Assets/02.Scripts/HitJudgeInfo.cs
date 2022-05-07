
using UnityEngine;

[CreateAssetMenu(menuName = "Hit Judge Info")]
public class HitJudgeInfo : ScriptableObject
{
    [Header(" ____Bad 판정 높이____")]
    public float hitJudgeHeight_Bad;
    [Header(" ____Miss 판정 높이____")]
    public float hitJudgeHeight_Miss;
    [Header(" ____Good 판정 높이____")]
    public float hitJudgeHeight_Good;
    [Header(" ____Great 판정 높이____")]
    public float hitJudgeHeight_Great;
    [Header(" ____Cool 판정 높이____")]
    public float hitJudgeHeight_Cool;
}
