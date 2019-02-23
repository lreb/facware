using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Utility.Common
{
    public class ConfigMap : Dictionary<object, object>
    {

        public ConfigMap()
        {
        }

        public object Get(object key, object defaultValue)
        {
            bool exist = this.ContainsKey(key);
            object s = !exist ? defaultValue : this[key];
            return s;
        }
        public string GetString(object key)
        {
            if (this.ContainsKey(key) && null != this[key])
            {
                return (string)this[key].ToString();
            }
            return null;
        }

        public string GetString(object key, string def)
        {
            if (this.ContainsKey(key) && null != this[key])
            {
                return (string)this[key].ToString();
            }
            return def;
        }

        public bool? GetBoolean(object key)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Boolean))
            {
                return (bool)this[key];
            }
            //if (this.ContainsKey(key) && this[key].GetType() == typeof(String) && (this[key].ToString().Equals("true", StringComparison.InvariantCultureIgnoreCase) || this[key].ToString().Equals("false", StringComparison.InvariantCultureIgnoreCase)))
            //{
            //    return bool.Parse(this[key].ToString().ToLower());
            //}
            return null;
        }

        public bool GetBoolean(object key, bool def)
        {
            if (this.ContainsKey(key) && null != this.GetBoolean(key))
            {
                return (bool)this[key];
            }

            return def;
        }

        public int? GetInt(object key)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int16))
            {
                return (Int16)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int32))
            {
                return (Int32)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int64))
            {
                return int.Parse(this[key].ToString());
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(int))
            {
                return (int)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(String))
            {
                return Int32.Parse(this[key].ToString());
            }
            return null;
        }

        public int GetInt(object key, int def)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int16))
            {
                return (Int16)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int32))
            {
                return (Int32)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int64))
            {
                return int.Parse(this[key].ToString());
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(int))
            {
                return (int)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(String))
            {
                return int.Parse(this[key].ToString());
            }
            return def;
        }

        public long? GetLong(object key)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int64))
            {
                return long.Parse(this[key].ToString());
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(long))
            {
                return (long)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int32))
            {
                return long.Parse(this[key].ToString());
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(String))
            {
                return long.Parse(this[key].ToString());
            }
            return null;
        }

        public long GetLong(object key, long def)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(Int64))
            {
                return (Int64)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(long))
            {
                return (long)this[key];
            }
            return def;
        }

        public DateTime? GetDatetime(object key, string format, DateTime? def)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(DateTime))
            {
                DateTime oDate = DateTime.ParseExact(key.ToString(), format, null);
                return oDate;
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(String))
            {
                DateTime oDate = DateTime.ParseExact(this[key].ToString(), format, null);
                return oDate;
            }
            return def;
        }

        public float? GetFloat(object key)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(float))
            {
                return (int)this[key];
            }
            return null;
        }

        public float GetFloat(object key, float def)
        {
            if (this.ContainsKey(key) && null != this.GetFloat(key))
            {
                return (float)this[key];
            }
            return def;
        }

        public ICollection GetList(object key)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(IList))
            {
                return (IList)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(ArrayList))
            {
                return (ICollection)this[key];
            }
            return null;
        }

        public ICollection GetList(object key, ICollection def)
        {
            if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(IList))
            {
                return (IList)this[key];
            }
            else if (this.ContainsKey(key) && null != this[key] && this[key].GetType() == typeof(ArrayList))
            {
                return (ICollection)this[key];
            }
            return def;
        }

        public void Replace(object key, object value)
        {
            if (this.ContainsKey(key))
            {
                this.Remove(key);
                this.Add(key, value);
            }
            else
            {
                this.Add(key, value);
            }
        }

        public void AddRange(IDictionary source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            foreach (var key in source.Keys)
            {
                this.Add(key, source[key]);
            }
        }
    }
}
