using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAbnormal : AbnormalObject
{
    [SerializeField]private List<Sprite> sprites = new List<Sprite>();
    [SerializeField]private AbnormalType abnormalType;
    protected override void Abnormalize(CommonMessage message)
    {
        AbnormalType type = (AbnormalType)message.Mid;

        if (type == abnormalType)
        {
            // Assuming the sprite renderer is on the same GameObject as this script
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && sprites.Count > 0)
            {
                spriteRenderer.sprite = sprites[1]; // Change to the second sprite
            }
        }
    }
}
