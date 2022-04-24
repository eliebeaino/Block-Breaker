using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip deathBlockClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;

    // state variable
    [SerializeField] int timesHit;               // only serialized for debug 

    private void Start()
    {
        //count breakable blocks
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        { 
        level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (maxHits <= timesHit)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];

        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(deathBlockClip, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDeathCount();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparklesVFX();
    }
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
