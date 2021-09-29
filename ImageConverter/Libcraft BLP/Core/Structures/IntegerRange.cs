//
//  IntegerRange.cs
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

using System;

namespace Warcraft.Core.Structures
{
    /// <summary>
    /// A structure representing a float range with a maximum and minimum value.
    /// </summary>
    public struct IntegerRange
    {
        /// <summary>
        /// Gets the minimum value included in the range.
        /// </summary>
        public uint Minimum
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the maximum value included in the range.
        /// </summary>
        public uint Maximum
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether or not the range is inclusive - that is, if the <see cref="Minimum"/> and
        /// <see cref="Maximum"/> values are considered a part of the range.
        /// </summary>
        public bool IsInclusive
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerRange"/> struct from a maximum and minimum value.
        /// </summary>
        /// <param name="inMin">The minimum value in the range.</param>
        /// <param name="inMax">The maximum value in the range.</param>
        /// <param name="inIsInclusive">Whether or not the range is inclusive.</param>
        /// <returns>A new <see cref="Range"/> object.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// An <see cref="ArgumentOutOfRangeException"/> can be thrown if the minimum value is greater than the maximum
        /// value.
        /// </exception>
        public IntegerRange(uint inMin, uint inMax, bool inIsInclusive = true)
        {
            if (!(inMin <= inMax))
            {
                throw new ArgumentOutOfRangeException(nameof(inMin), "inMin must be less than or equal to inMax");
            }

            Minimum = inMin;
            Maximum = inMax;
            IsInclusive = inIsInclusive;
        }

        /// <summary>
        /// Creates a string representation of the current instance.
        /// </summary>
        /// <returns>A string representation of the current instance.</returns>
        public override readonly string ToString()
        {
            return $"Integer Range: {Minimum} to {Maximum}";
        }
    }
}
