using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public AudioSource point;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.points += 10;
        point.Play();
    }
}
