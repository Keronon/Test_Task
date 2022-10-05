using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_pointing : MonoBehaviour
{
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject player;
    [SerializeField] private float player_speed;

    private _Input_manager manager;
    private Camera camera_main;

    private Queue<Vector3> waypoints = new Queue<Vector3>();

    private void Awake()
    {
        manager = _Input_manager.Instance;
        camera_main = Camera.main;
    }

    private void OnEnable()
    {
        manager.OnStartTouch += Move;
    }
    private void OnDisable()
    {
        manager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screen_position, float time)
    {
        if (player.gameObject == null) return;

        Vector3 screen_coordinates = new Vector3(screen_position.x, screen_position.y, player.transform.position.z);
        Vector3 world_coordinates = camera_main.ScreenToWorldPoint(screen_coordinates);
        world_coordinates.z = 0;
        waypoints.Enqueue(world_coordinates);
    }

    void Update()
    {
        if (player.gameObject == null) return;

        if (waypoints.Count > 0)
        {
            int positions = line.GetComponent<LineRenderer>().positionCount;
            if (player.transform.position == waypoints.Peek())
            {
                waypoints.Dequeue();
                line.GetComponent<LineRenderer>().positionCount++;
                line.GetComponent<LineRenderer>().SetPosition(positions, line.GetComponent<LineRenderer>().GetPosition(positions - 1));
            }
            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, waypoints.Peek(), Time.deltaTime + (player_speed / 10));
                line.GetComponent<LineRenderer>().SetPosition(positions - 1, player.transform.position);
            }
        }
    }
}
