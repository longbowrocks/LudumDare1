using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private static float MIN_HEALTH = 0f;
    public static float MAX_HEALTH = 100f;
    private static float HEALTH_PER_SECOND = 1;
    public float currentHealth;
    private float startingScaleX;
    private float startingWidth;
    private float startingX;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MAX_HEALTH;
        startingScaleX = transform.localScale.x;
        startingWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startingX = transform.localPosition.x;
    }

    private void FixedUpdate()
    {
        currentHealth -= Time.fixedDeltaTime * HEALTH_PER_SECOND;
        currentHealth = Mathf.Clamp(currentHealth, MIN_HEALTH, MAX_HEALTH);

        var newScale = transform.localScale;
        newScale.x = startingScaleX * currentHealth / MAX_HEALTH;
        transform.localScale = newScale;

        var newLocalPos = transform.localPosition;
        var currentWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        newLocalPos.x = startingX - (startingWidth - currentWidth) / 2;
        transform.localPosition = newLocalPos;
    }
}
