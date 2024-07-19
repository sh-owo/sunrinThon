using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] int m_priority;
    [SerializeField] bool m_removeOnInteract;
    public int priority { get { return m_priority; } }
    public bool removeOnInteract { get { return m_removeOnInteract;} }
    public virtual void OnInteract()
    {

    }
}
