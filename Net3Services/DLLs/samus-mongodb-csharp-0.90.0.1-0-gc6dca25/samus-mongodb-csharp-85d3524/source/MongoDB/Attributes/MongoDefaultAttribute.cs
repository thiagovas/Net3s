﻿using System;

namespace MongoDB.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class MongoDefaultAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MongoDefaultAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public MongoDefaultAttribute(object value){
            Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; private set; }
    }
}