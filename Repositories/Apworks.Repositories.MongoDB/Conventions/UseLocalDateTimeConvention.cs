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
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;

namespace Apworks.Repositories.MongoDB.Conventions
{
    /// <summary>
    /// Represents the Bson serialization convention that serializes the <see cref="System.DateTime"/> value
    /// by using the local date/time kind.
    /// </summary>
    public class UseLocalDateTimeConvention : ISerializationOptionsConvention
    {
        #region ISerializationOptionsConvention Members
        /// <summary>
        /// Gets the BSON serialization options for a member.
        /// </summary>
        /// <param name="memberInfo">The member.</param>
        /// <returns>The BSON serialization options for the member; or null to use defaults.</returns>
        public virtual IBsonSerializationOptions GetSerializationOptions(MemberInfo memberInfo)
        {
            switch(memberInfo.MemberType)
            {
                case MemberTypes.Property:
                    PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
                    if (propertyInfo.PropertyType == typeof(DateTime) ||
                        propertyInfo.PropertyType == typeof(DateTime?))
                        return new DateTimeSerializationOptions(DateTimeKind.Local);
                    break;
                case MemberTypes.Field:
                    FieldInfo fieldInfo = (FieldInfo)memberInfo;
                    if (fieldInfo.FieldType == typeof(DateTime) ||
                        fieldInfo.FieldType == typeof(DateTime?))
                        return new DateTimeSerializationOptions(DateTimeKind.Local);
                    break;
                default:
                    break;
            }
            return null;
        }

        #endregion
    }
}
