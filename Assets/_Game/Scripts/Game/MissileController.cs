using UnityEngine;
using UnityEngine.AI;

namespace LightItUp.Game
{
    public class MissileController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        [Tooltip("Reference to the agent attached to this gameobjects behavior.")]
        NavMeshAgent agent;

        [Header("Tweakables")]
        [SerializeField]
        float updateThreshold = 0.1f;

        /// <summary>
        /// Retains the target to check if the target becomes lit by other sources
        /// </summary>
        [Header("Properties")]
        BlockController currentTarget;

        /// <summary>
        /// Initialize the missile with a spawn position and a target.
        /// </summary>
        /// <param name="spawnPosition">Initial position.</param>
        /// <param name="target">Target to be followed, even if it moves.</param>
        public virtual void Initialize(Transform spawnPosition, BlockController target)
        {
            transform.position = spawnPosition.position;
            agent.SetDestination(target.transform.position);
            currentTarget = target;
        }

        private void Update()
        {
            //If target is destroyed or becomes lit, clear it.
            if (currentTarget == null || currentTarget.IsLit)
            {
                Destroy(gameObject);
            }
            else
            {
                //Check for position changes, and update it if it becomes too much
                if (Vector3.Distance(currentTarget.transform.position, transform.position) > updateThreshold)
                    agent.SetDestination(currentTarget.transform.position);
            }
        }
    }
}