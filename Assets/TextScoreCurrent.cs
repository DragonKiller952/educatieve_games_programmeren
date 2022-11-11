// Copyright 2021, Infima Games. All Rights Reserved.

using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

namespace InfimaGames.LowPolyShooterPack.Interface
{
    /// <summary>
    /// Current Ammunition Text.
    /// </summary>
    public class TextScoreCurrent : ElementText
    {
        #region METHODS

        /// <summary>
        /// Tick.
        /// </summary>
        protected override void Tick()
        {
            //Current Ammunition.
            float current = playerCharacter.GetScoreCurrent();
            
            //Update Text.
            textMesh.text = current.ToString(CultureInfo.InvariantCulture);
        }
        
        #endregion
    }
}