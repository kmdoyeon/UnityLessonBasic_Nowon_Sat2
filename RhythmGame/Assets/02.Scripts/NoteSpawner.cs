using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public KeyCode keyCode;
    public GameObject notePrefab;

    public void SpwanNote()
    {
        GameObject note = Instantiate(notePrefab, transform.position, Quaternion.identity);
    }
}
