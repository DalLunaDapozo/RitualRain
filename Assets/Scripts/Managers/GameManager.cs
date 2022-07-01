using System;
using UnityEngine;

[SerializeField] public enum GameState { Starting, Win, Lose}

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    public GameState State { get; private set; }

    private void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:

                InputManager.GetInstance().EnableInput();

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
