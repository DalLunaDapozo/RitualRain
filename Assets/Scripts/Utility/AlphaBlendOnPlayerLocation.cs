using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AlphaBlendOnPlayerLocation : MonoBehaviour
{
    [SerializeField] private EntityCurrentRoom player;

    [SerializeField] private CurrentRoom[] roomsWhereWallsFadeIn;

    public  CurrentRoom playerLocation;
    private Tilemap tilemap;

    public bool alphaChanged;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        alphaChanged = false;
    }

    private void Update()
    {
        CheckPlayerPos();
        AlphaBlendifPlayerIsInRoom();
    }
    
    private void AlphaBlendifPlayerIsInRoom()
    {

        for (int i = 0; i < roomsWhereWallsFadeIn.Length; i++)
        {
            if (playerLocation == CurrentRoom.Closet || playerLocation == CurrentRoom.Bedroom || playerLocation == CurrentRoom.Bathroom && !alphaChanged)
            {
                StartCoroutine(SpriteFade(tilemap, 1f, 3f));
                alphaChanged = true;
            }
            else
            {
                StartCoroutine(SpriteFade(tilemap, 0f, 1f));
                alphaChanged = false;
            }
        } 
    }

    public IEnumerator SpriteFade(Tilemap sr, float endValue, float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }

 

    private void CheckPlayerPos()
    {
        playerLocation = player.entityCurrentRoom;
    }
}
