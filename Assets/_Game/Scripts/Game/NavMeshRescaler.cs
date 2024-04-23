using LightItUp.Data;
using UnityEngine;

namespace LightItUp.Game
{
    /// <summary>
    /// Rescales based on level size to not recalcualte area larger than it should be.
    /// </summary>
    public class NavMeshRescaler : MonoBehaviour
    {
        private void OnEnable()
        {
            GameManager.Instance.OnLevelLoaded += Rescale;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnLevelLoaded -= Rescale;
        }
        private void Rescale()
        {
            var levelRect = GameManager.Instance.currentLevel.LevelRect;
            transform.localScale = new Vector3(levelRect.width, levelRect.height, 1);           
        }
    }
}