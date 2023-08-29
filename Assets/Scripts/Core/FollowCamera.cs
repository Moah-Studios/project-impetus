using UnityEngine;

namespace RPG.Core
{
    /// <summary>
    /// A class for the camera that follows the Player through the world.
    /// </summary>
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        // Ensures that the follow camera is the last thing that moves to prevent jitters with the Player moving. 
        void LateUpdate()
        {
            transform.position = target.position;
        }
    }
}