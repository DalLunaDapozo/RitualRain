using System;
using UnityEngine;

[SerializeField] public enum GameState { Starting, Spawning, Gameplay, CutScene, Dialogue, Win, Lose}

public class GameManager : Singleton<GameManager>
{
    public event Action<GameState> OnBeforeStateChanged;

    public bool testMode = false;

    public GameState State { get; private set; }

    private void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:

                ChangeState(GameState.Gameplay);

                break;
            
            case GameState.Dialogue:

                InputManager.GetInstance().EnterCutSceneMode();

                break;

            case GameState.Gameplay:

                InputManager.GetInstance().ExitCutSceneMode();

                break;

            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }

    }

}
