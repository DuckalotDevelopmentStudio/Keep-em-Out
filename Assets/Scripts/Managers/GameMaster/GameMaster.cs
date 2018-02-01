using UnityEngine;

public enum GameState
{
    InWave,
    AfterWave,
    Paused
}

namespace Project.Managers
{
    
    public class GameMaster : MonoBehaviour                     /// <summary>Takes care of managing what's going on in the game</summary>
    {
        public GameState gameState = GameState.InWave;          /// <summary>Current game's state</summary>

        public void SwitchGameState(GameState desiredState)     /// <summary>Switches the current game state</summary> /// <param name="desiredState">The desired state to switch to</param>
        {
            gameState = desiredState;
        }
    }
}
