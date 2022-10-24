// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine.
    /// </summary>
    public class Magazine : MagazineBehaviour
    {
        #region FIELDS SERIALIZED

        [Header("Settings")]
        
        [Tooltip("Total Ammunition.")]
        [SerializeField]
        private int ammunitionTotal = 50;

        [Tooltip("Total Ammunition.")]
        [SerializeField]
        private int clipTotal = 10;

        [Header("Interface")]

        [Tooltip("Interface Sprite.")]
        [SerializeField]
        private Sprite sprite;

        #endregion

        #region GETTERS

        /// <summary>
        /// Ammunition Total.
        /// </summary>
        public override int GetAmmunitionTotal() => ammunitionTotal;
        /// <summary>
        /// Clip Total.
        /// </summary>
        public override int GetClipTotal() => clipTotal;
        /// <summary>
        /// Sprite.
        /// </summary>
        public override Sprite GetSprite() => sprite;

        #endregion
    }
}