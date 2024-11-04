using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : MonoBehaviour
{
    List<Item> handItem = new List<Item>();
    

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (handItem.Count > 0)
            {
                handItem[0].Drop(transform);
                handItem.RemoveAt(0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        I_Collectable collectableItem;

        if (other.TryGetComponent<I_Collectable>(out collectableItem))
        {
            collectableItem.Get();
            handItem.Add(other.GetComponent<Item>());
        }
    }
}
