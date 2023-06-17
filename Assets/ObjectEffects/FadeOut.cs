using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float timeToDisapear;
    private SpriteRenderer renderer;
    private Color color;
    public UnityEvent OnFadedOut;
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
            Destroy(this);
    }
    private void OnEnable()
    {
        color = renderer.color;
        color.a = 1f;
        renderer.color = color;
    }
    void Update()
    {
        color.a -= (Time.deltaTime / timeToDisapear);
        renderer.color = color;
        if (color.a <= 0)
            OnFadedOut?.Invoke();
    }
}
