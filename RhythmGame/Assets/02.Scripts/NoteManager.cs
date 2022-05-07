using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;
    public static float noteSpeedScale = 1f;

    [SerializeField] private Transform spawnersParent;
    [SerializeField] private Transform hittersParent;   
    public float noteFallingDistance
    {
        get
        {
            return spawnersParent.position.y - hittersParent.position.y;
        }
         
    }

    public float noteFallingTime
    {
        get
        {
            return noteFallingDistance / noteSpeedScale;
        }
    }

    private Dictionary<KeyCode, NoteSpawner> spawners = new Dictionary<KeyCode,NoteSpawner>();
    private Queue<NoteData> noteQueue = new Queue<NoteData>();

    

    //=======================================================================
    //***************************Private Methods*****************************
    //=======================================================================

    public void StarSpawn()
    {
        if (noteQueue.Count > 0)
            StartCoroutine(E_Spawning());

    }

    IEnumerator E_Spawning()
    {
        float startTimeMark = Time.time;
        while (noteQueue.Count > 0)
        {  
            for (int i = 0; i < noteQueue.Count; i++)
            {
                if (noteQueue.Peek().time < (Time.time - startTimeMark ) / noteSpeedScale)                 
                {
                    /* NoteData note = noteQueue.Dequeue();
                    if (note.speed > 0)
                        spawners[note.keyCode].SpwanNote().speed = note.speed;
                    else
                        spawners[note.keyCode].SpwanNote(); */
                }
                else
                    break;
            }

            yield return null;
        }
    }

    //=======================================================================
    //***************************Private Methods*****************************
    //=======================================================================

    private void Awake()
    {
        instance = this;

        NoteSpawner[] tmpSpawners = spawnersParent.GetComponentsInChildren<NoteSpawner>();
        foreach (NoteSpawner spawner in tmpSpawners)
        {
            spawners.Add(spawner.keyCode, spawner);
        }

        // 노트  데이터들 큐에 시간순등록
        List<NoteData> notes = SongSelector.instance.songData.notes;
        /*for(int i = 0; i < notes.Count; i++)
        {
            float speedOrigin = notes[i].time / NoteAssets.GetNote(notes[i].keyCode).speed;

            float tmpSpeed = 0;
            if (speedOrigin != notes[i].speed)

            notes[i] = new NoteData
            {
                keyCode = notes[i].keyCode,
                time = timeScaled,
            }; 
        }*/

        notes.Sort((x, y) => x.time.CompareTo(y.time));
        foreach (NoteData note in SongSelector.instance.songData.notes)
        {
            Debug.Log($" enqueue note {note.keyCode}, {note.time}");
            noteQueue.Enqueue(note);
        }
    }
}
