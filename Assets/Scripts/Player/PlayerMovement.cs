using UnityEngine;
using Project.Player;
using Project.Managers;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private Player player = null;               // Reference to the attached Player script

    void Start()
    {
        player = GetComponent<Player>();        // Actually assign the Player script to the variable
    }

    void Update()
    {
        MovePlayer();                           // Move the player
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"),
                                        0,
                                        Input.GetAxisRaw("Vertical")).normalized * player.charStats.movementSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World); // Change to rb.velocity?
    }
}
