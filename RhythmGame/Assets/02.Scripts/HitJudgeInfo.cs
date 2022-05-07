
using UnityEngine;

[CreateAssetMenu(menuName = "Hit Judge Info")]
public class HitJudgeInfo : ScriptableObject
{
    [Header(" ____Bad ���� ����____")]
    public float hitJudgeHeight_Bad;
    [Header(" ____Miss ���� ����____")]
    public float hitJudgeHeight_Miss;
    [Header(" ____Good ���� ����____")]
    public float hitJudgeHeight_Good;
    [Header(" ____Great ���� ����____")]
    public float hitJudgeHeight_Great;
    [Header(" ____Cool ���� ����____")]
    public float hitJudgeHeight_Cool;
}
