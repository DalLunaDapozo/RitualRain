using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Greg greg;

    private PlayableDirector director;

    [SerializeField] private PlayableAsset[] cutscenes;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        greg.player_is_well_hidden += Player_well_hidden_scene;
        greg.player_is_not_well_hidden += Player_not_well_hidden_scene;
    }

    private void Player_well_hidden_scene(object sender, EventArgs e)
    {
        PlayableAsset _scene;
        for (int i = 0; i < cutscenes.Length; i++)
        {
            if (cutscenes[i].name == "greg_test")
            {
                _scene = cutscenes[i];
                director.Play(_scene);
                return;
            }
        }
    }

    private void Player_not_well_hidden_scene(object sender, EventArgs e)
    {
        PlayableAsset _scene;
        for (int i = 0; i < cutscenes.Length; i++)
        {
            if (cutscenes[i].name == "greg_test")
            {
                _scene = cutscenes[i];
                director.Play(_scene);
                return;
            }
        }
    }
}
