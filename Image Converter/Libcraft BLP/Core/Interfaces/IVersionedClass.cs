﻿//
//  IVersionedClass.cs
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

namespace Warcraft.Core.Interfaces
{
    /// <summary>
    /// The IVersionedClass interface does not require any specific functionality, but rather acts as a decorator to
    /// provide generic functions with the knowledge that the class which implements it has multiple deserialization
    /// paths depending on different versions of its own or its containing object's class.
    /// </summary>
    public interface IVersionedClass
    {
    }
}
