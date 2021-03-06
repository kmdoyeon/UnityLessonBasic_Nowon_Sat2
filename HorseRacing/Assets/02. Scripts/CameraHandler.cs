using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private Transform tr;
    private List<Transform> players = new List<Transform>();
    private int targetindex = 0;
    public Vector3 offset = new Vector3(0, 2, -4);

    private void Awake()
    {
        tr = transform;
    }

    private void Start()
    {
        foreach (var item in GamePlay.instance.players)
        {
            players.Add(item.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(GamePlay.instance.onPlay)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                SwitchTarget();
            }
        }
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void SwitchTarget()
    {
        targetindex++;
        if (targetindex > players.Count - 1)
            targetindex = 0;
    }
    private void FollowTarget()
    {
        tr.position = players[targetindex].position + offset;
    }
}
