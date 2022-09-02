using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect : MonoBehaviour
{
    public Color Startcolor = Color.black;
    public Color endcolor = Color.white;

    [Range(0,10)] public float speed = 0.5f;

    Renderer ren;

    private void Awake() {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ren.material.color = Color.Lerp(Startcolor, endcolor, Mathf.PingPong(Time.time*speed, 1));
    }
}
