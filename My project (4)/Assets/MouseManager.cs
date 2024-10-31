using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    public EventEnviroment OnClickEnviroment;
    public LayerMask maskInteractable;

    public Texture2D pointer;
    public Texture2D target;
    public Texture2D doorWay;
    public Texture2D doorBack;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        if(Physics.Raycast(ray, out hit, 100, maskInteractable))
        {
            switch (hit.collider.tag)
            {
                case Tags.FLOOR:
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case Tags.ROCK:
                    Cursor.SetCursor(pointer, new Vector2(0, 0), CursorMode.Auto);
                    break;
                case Tags.DOORWAY:
                    Cursor.SetCursor(doorWay, new Vector2(16, 16), CursorMode.Auto);
                    break;
                case Tags.DOOR_BACK:
                    Cursor.SetCursor(doorBack, new Vector2(16, 16), CursorMode.Auto);
                    break;
                default:
                    Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                EventArgs args;
                switch (hit.collider.tag)
                {
                    case Tags.FLOOR:
                        args = new EventArgs();
                        args.position = hit.point;
                        OnClickEnviroment.Invoke(args);
                        break;
                    case Tags.DOORWAY:
                        args = new EventArgs();
                        args.position = hit.collider.GetComponent<Door>().destination;
                        OnClickEnviroment.Invoke(args);
                        break;
                    case Tags.DOOR_BACK:
                        args = new EventArgs();
                        args.position = hit.collider.GetComponent<Door>().destination;
                        OnClickEnviroment.Invoke(args);
                        break;
                }
            }
        }
        else
        {
            Cursor.SetCursor(pointer, new Vector2(0, 0), CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventEnviroment : UnityEvent<EventArgs> { }

public class EventArgs
{
    public Vector3 position;
}
