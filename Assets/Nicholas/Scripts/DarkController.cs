using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class DarkController : MonoBehaviour
{
    [SerializeField] Tilemap tmGround;
    [SerializeField] Tilemap tmWall;
    [SerializeField] Tilemap tmMagnet;
    [SerializeField] SpriteRenderer Magnet;
    [SerializeField] SpriteRenderer Background1;
    [SerializeField] SpriteRenderer Background2;
    [SerializeField] Playermovement Player;
    [SerializeField] SpriteRenderer PlayerField;
    [SerializeField] AudioSource au;
    [SerializeField] Volume vm;

    public bool isDark;
    private bool soundPlayed;
    private void Update()
    {
        if(Player.polarity == -1) // blue
        {
            PlayerField.color = new Color32(0,100,255,100);
        }
        else if(Player.polarity == 1) // red
        {
            PlayerField.color = new Color32(255,0,0,100);
        }
        else // purple
        {
            PlayerField.color = new Color32(255,0,255,100);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDark = true;
            PlayerField.enabled = true;
            tmGround.color = new Color32(0,0,0,255);
            tmWall.color = new Color32(0,0,0,255);
            Magnet.color = new Color32(0,0,0,255);
            tmMagnet.color = new Color32(0,0,0,255);
            Background1.color = new Color32(0,0,0,255);
            Background2.color = new Color32(0,0,0,255);
            Player.sr.color = new Color32(0,0,0,255);
            // global volume changes

            if (vm.profile.TryGet(out ColorAdjustments colorA))
            {
                colorA.active = false;
            }
            if (vm.profile.TryGet(out LiftGammaGain lgg))
            {
                lgg.active = false;
            }


            if (!soundPlayed)
            {
                au.Play();
                soundPlayed = true;
            }
        }
    }

}
