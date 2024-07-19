using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collider2DStatus : MonoBehaviour
{
    List<Collider2D> colliders = new();
    [SerializeField] string detectTag = "Map";
    public bool isTouching { get { return colliders.Count > 0; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag)) colliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(detectTag)) colliders.Remove(collision);
    }
}
