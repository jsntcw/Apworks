﻿// ==================================================================================================================                                                                                          
//        ,::i                                                           BBB                
//       BBBBBi                                                         EBBB                
//      MBBNBBU                                                         BBB,                
//     BBB. BBB     BBB,BBBBM   BBB   UBBB   MBB,  LBBBBBO,   :BBG,BBB :BBB  .BBBU  kBBBBBF 
//    BBB,  BBB    7BBBBS2BBBO  BBB  iBBBB  YBBJ :BBBMYNBBB:  FBBBBBB: OBB: 5BBB,  BBBi ,M, 
//   MBBY   BBB.   8BBB   :BBB  BBB .BBUBB  BB1  BBBi   kBBB  BBBM     BBBjBBBr    BBB1     
//  BBBBBBBBBBBu   BBB    FBBP  MBM BB. BB BBM  7BBB    MBBY .BBB     7BBGkBB1      JBBBBi  
// PBBBFE0GkBBBB  7BBX   uBBB   MBBMBu .BBOBB   rBBB   kBBB  ZBBq     BBB: BBBJ   .   iBBB  
//BBBB      iBBB  BBBBBBBBBE    EBBBB  ,BBBB     MBBBBBBBM   BBB,    iBBB  .BBB2 :BBBBBBB7  
//vr7        777  BBBu8O5:      .77r    Lr7       .7EZk;     L77     .Y7r   irLY  JNMMF:    
//               LBBj
//
// Apworks Application Development Framework
// Copyright (C) 2010-2011 apworks.codeplex.com.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ==================================================================================================================

using System;

namespace Apworks.Commands
{
    /// <summary>
    /// Represents the base class of the commands.
    /// </summary>
    [Serializable]
    public class Command : ICommand
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <c>Command</c> class.
        /// </summary>
        public Command()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <c>Command</c> class.
        /// </summary>
        /// <param name="id">The identifier which identifies a single command instance.</param>
        public Command(Guid id)
        {
            this.ID = id;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the hash code for current command object.
        /// </summary>
        /// <returns>The calculated hash code for the current command object.</returns>
        public override int GetHashCode()
        {
            return Utils.GetHashCode(this.ID.GetHashCode());
        }
        /// <summary>
        /// Returns a <see cref="System.Boolean"/> value indicating whether this instance is equal to a specified
        /// object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>True if obj is an instance of the <see cref="Apworks.Commands.ICommand"/> type and equals the value of this
        /// instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Command cmd = obj as Command;
            if ((object)cmd == null)
                return false;
            return this.Equals((IEntity)cmd);
        }
        #endregion

        #region IEntity Members
        /// <summary>
        /// Gets or sets the identifier of the command instance.
        /// </summary>
        public virtual Guid ID
        {
            get;
            set;
        }

        #endregion

        #region IEquatable<IEntity> Members
        /// <summary>
        /// Returns a <see cref="System.Boolean"/> value indicating whether this instance is equal to a specified
        /// object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>True if obj is an instance of the <see cref="Apworks.Commands.ICommand"/> type and equals the value of this
        /// instance; otherwise, false.</returns>
        public virtual bool Equals(IEntity other)
        {
            if (object.ReferenceEquals(this, other))
                return true;
            if ((object)other == null)
                return false;
            if (!(other is Command))
                return false;
            Command otherCommand = other as Command;
            return this.ID.Equals(otherCommand.ID);
        }

        #endregion

    }
}
