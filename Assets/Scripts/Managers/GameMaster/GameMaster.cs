using UnityEngine;

public enum GameState
{
    InWave,
    AfterWave,
    Paused,
    GameOver
}

namespace Project.Managers
{
    /// <summary>
    /// Game's manager. Stores the game's state and runs logic depending on that state
    /// </summary>
    public class GameMaster : MonoBehaviour
    {
        [HideInInspector]
        /// <summary>
        /// The instance of GameMaster
        /// </summary>
        public static GameMaster instance = null;

        /// <summary>
        /// Current game state
        /// </summary>
        public GameState gameState = GameState.InWave;

        void Awake()
        {
            #region Singleton
            if (instance != this)
            {
                print("More than one instance of " + this.name + ". （╯ ͡°  ل͜ ͡°）╯︵ ┻━┻");
            }
            instance = this;
            #endregion
        }

        void Start()
        {
            Player.Player.PlayerDied.AddListerner(PlayerDied, "OnPlayerDied");
        }

        void LateUpdate()
        {
            switch(gameState)
            {
                case GameState.InWave:
                    // Lock the cursor
                    // Run InWave logic things
                    Time.timeScale = 1;
                    break;
                case GameState.AfterWave:
                    // Add a cooldown (PROTOTYPE ONLY)
                    // Soldier buying logic (depends on whether or not we'll want to continue working on this game after the prototype)
                    break;
                case GameState.Paused:
                    // Show pause menu
                    Time.timeScale = 0;
                    break;
                case GameState.GameOver:
                    // Game Over stuff
                    break;
            }
        }

        /// <summary>
        /// Switches the current game state to the desired state
        /// </summary>
        /// <param name="desiredState">Desired state to switch to</param>
        public void SwitchGameState(GameState desiredState)
        {
            gameState = desiredState;
            print("GameState | " + gameState.ToString());
        }

        /// <summary>
        /// Contains everything to happen on the player's death
        /// </summary>
        public void PlayerDied()
        {
            SwitchGameState(GameState.GameOver);
        }
    }
}
