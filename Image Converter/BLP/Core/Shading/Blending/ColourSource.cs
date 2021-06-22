﻿//
//  ColourSource.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

namespace Warcraft.Core.Shading.Blending
{
    /// <summary>
    /// Different algorithms to use for source RGB blending factors.
    /// The given values are taken from OpenGL for ease of use.
    /// </summary>
    public enum ColourSource
    {
        /// <summary>
        /// A factor of one.
        /// </summary>
        One = 1,

        /// <summary>
        /// The source alpha is used as the factor.
        /// </summary>
        SourceAlpha = 770,

        /// <summary>
        /// One minus the source alpha is used as the factor.
        /// </summary>
        OneMinusSourceAlpha = 771,

        /// <summary>
        /// The destination colour is used as the factor.
        /// </summary>
        DestinationColour = 774,

        /// <summary>
        /// One minus the destination colour is used as the factor.
        /// </summary>
        OneMinusDestionationColour = 775,

        /// <summary>
        /// A constant alpha value is used as the factor.
        /// </summary>
        ConstantAlpha = 32771
    }
}
