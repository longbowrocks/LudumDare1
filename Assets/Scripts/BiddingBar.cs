using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingBar : MonoBehaviour
{
    public static float MAX_BID_RATIO = 0.75f;
    private Color baseColor;
    public float currentBid;
    private float startingScaleX;
    public float width;
    public float widthDiff;
    // Start is called before the first frame update
    void Start()
    {
        baseColor = GetComponent<SpriteRenderer>().color;
        startingScaleX = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        var healthBarController = GetComponentInParent<HealthBar>();
        currentBid = Mathf.Clamp(currentBid, 0, healthBarController.currentHealth*MAX_BID_RATIO);

        var newScale = transform.localScale;
        newScale.x = startingScaleX * currentBid / HealthBar.MAX_HEALTH;
        transform.localScale = newScale;

        //TODO right-align bid bar against health bar.
        //var newLocalPos = transform.localPosition;
        //var currentWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        //newLocalPos.x = healthBarController.startingX - (startingWidth - currentWidth) / 2;
        //transform.localPosition = newLocalPos;

        //var renderer = GetComponent<SpriteRenderer>();
        //var newScale = transform.localScale;
        //var oldWidth = renderer.bounds.size.x;
        //transform.localScale = newScale;
        //// Find new position for width so position is left-aligned to parent.
        //var newLocalPos = transform.localPosition;
        //var newWidth = renderer.bounds.size.x;
        //width = newWidth;
        //widthDiff = oldWidth - newWidth;
        //newLocalPos.x = newLocalPos.x + (oldWidth - newWidth) / 2;
        //transform.localPosition = newLocalPos;
    }

    private void Update()
    {
        float colorDelta = 0.2f + 0.1f * Mathf.Sin(Time.time * 12);
        var renderer = GetComponent<SpriteRenderer>();
        renderer.color = new Color(
            baseColor.r + baseColor.r * colorDelta,
            baseColor.g + baseColor.g * colorDelta,
            baseColor.b + baseColor.b * colorDelta,
            baseColor.a
            );
    }
}
