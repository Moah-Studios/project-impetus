using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement
{
    /// <summary>
    /// Dictates the Player's movement.
    /// </summary>
    public class Mover : MonoBehaviour
    {
        // The "target" area to move to 
        [SerializeField] Transform target;

        NavMeshAgent navMeshAgent;

        private void Start() {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        public void StartMoveAction(Vector3 destination) 
        {
            GetComponent<Fighter>().Cancel();
            MoveTo(destination);
        }

        /// <summary>
        /// Moves the Player to the provided destination.
        /// </summary>
        /// <param name="destination">The destination to move to.</param>
        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        /// <summary>
        /// Stops the Player from moving.
        /// </summary>
        public void Stop() 
        {
            navMeshAgent.isStopped = true;
        }

        /// <summary>
        /// Communicates to the animator on the Player how fast it should be moving to make the movement look realistic.
        /// </summary>
        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}