// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Player Interface.
    /// </summary>
    public class CanvasSpawner : MonoBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]
        
        [Tooltip("Canvas prefab spawned at start. Displays the player's user interface.")]
        [SerializeField]
        private GameObject canvasPrefab;
        [SerializeField]
        private GameObject pausePrefab;

        #endregion

        #region UNITY FUNCTIONS

        /// <summary>
        /// Awake.
        /// </summary>
        private void Awake()
        {
            //Spawn Interface.
            GameObject canvas = Instantiate(canvasPrefab);
            canvas.transform.SetParent(transform);

            GameObject pause = Instantiate(pausePrefab);
            pause.transform.SetParent(transform);
            pause.SetActive(false);
        }

        #endregion
    }
}