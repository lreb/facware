using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Utility.Common
{
    /// <summary>
    /// Allows to create an input parameter for services, with key,
    /// parameter class type and a mandatory flag
    /// </summary>
    public class InputParam
    {

        private String Key;
        private Type Klass;
        private Boolean Mandatory;
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="key">Parameter Name</param>
        /// <param name="type"> Class Type</param>
        /// <param name="mandatory">Parameter mandatory flag. If true, parameter must exist when validated</param>
        public InputParam(String key, Type klass, Boolean mandatory)
        {
            this.Key = key;
            this.Klass = klass;
            this.Mandatory = mandatory;
        }
        /// <summary>
        /// Creates an InputParam instance, with mandatory flag set to true
        /// </summary>
        /// <param name="key">Parameter Name</param>
        /// <param name="type">Parameter Class Type</param>
        /// <returns>New Instance</returns>
        public static InputParam CreateMandatoryParam(String key, Type type)
        {
            return new InputParam(key, type, true);
        }
        /// <summary>
        /// Creates an InputParam instance, with mandatory flag set to false
        /// </summary>
        /// <param name="key">Parameter Name</param>
        /// <param name="type">Parameter Class Type</param>
        /// <returns>New Instance</returns>
        public static InputParam CreateOptionalParam(String key, Type type)
        {
            Type a = key.GetType();
            return new InputParam(key, type, false);
        }
        /// <summary>
        /// Creates an InputParam instance with Class type set to String and mandatory flag set to false 
        /// </summary>
        /// <param name="key">Parameter Name</param>
        /// <param name="type">Parameter Class Type</param>
        /// <returns>New Instance</returns>
        public static InputParam CreateOptionalParam(String key)
        {
            return new InputParam(key, key.GetType(), false);
        }

        /// <summary>
        /// Creates an InputParam instance with Class type set to String and mandatory flag set to false 
        /// </summary>
        /// <param name="key">Parameter Name</param>
        /// <param name="type">Parameter Class Type</param>
        /// <returns>New Instance</returns>
        public static InputParam CreateMandatoryParam(String key)
        {
            return new InputParam(key, key.GetType(), true);
        }

        /// <summary>
        /// Provides the object fields, and mandatory status
        /// </summary>
        /// <returns>Object fields, and mandatory status</returns>
        public override string ToString()
        {
            return "InputParam(Name:" + Key + " Type:" + Klass + " (" + (Mandatory ? "Mandatory" : "Optional") + "))";
        }

        public String GetKey()
        {
            return this.Key;
        }

        public void SetKey(String key)
        {
            this.Key = key;
        }

        public Type GetClass()
        {
            return this.Klass;
        }

        public void SetType(Type klass)
        {
            this.Klass = klass;
        }

        public bool IsMandatory()
        {
            return this.Mandatory;
        }

        public void SetMandatory(bool mandatory)
        {
            this.Mandatory = mandatory;
        }
    }
}
