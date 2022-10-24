// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.LowPolyShooterPack
{
    /// <summary>
    /// Magazine Behaviour.
    /// </summary>
    public abstract class MagazineBehaviour : MonoBehaviour
    {
        #region GETTERS
        
        /// <summary>
        /// Returns The Total Ammunition.
        /// </summary>
        public abstract int GetAmmunitionTotal();
        /// <summary>
        /// Returns The Total Clip.
        /// </summary>
        public abstract int GetClipTotal();
        /// <summary>
        /// Returns the Sprite used on the Character's Interface.
        /// </summary>
        public abstract Sprite GetSprite();

        #endregion
    }
}