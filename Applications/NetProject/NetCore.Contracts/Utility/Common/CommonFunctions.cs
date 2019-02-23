using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Utility.Common
{
    public class CommonFunctions
    {
        public static Boolean IsValidObject(Object o)
        {
            if (null == o)
            {
                return false;
            }
            if (o.GetType() == typeof(String))
            {
                if (!o.ToString().Trim().Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (o.GetType().GetInterface(nameof(ICollection)) != null)
            {
                if (((ICollection)o).Count > 0 && !o.ToString().Trim().Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (o.GetType().GetInterface(nameof(IList)) != null)
            {
                if ((((IList)o).Count > 0 && !o.ToString().Trim().Equals("")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (o.GetType() == typeof(int) || o.GetType() == typeof(bool) || o.GetType() == typeof(long) || o.GetType() == typeof(Int64))
            {
                return true;
            }

            return true;
        }

        public static Boolean IsValidObjectList(object[] list)
        {
            foreach (object a in list)
            {
                bool result = CommonFunctions.IsValidObject(a);
                if (!result)
                {
                    return result;
                }
            }
            return true;
        }

        /// <summary>
        /// Create a sequence id to external events
        /// </summary>
        /// <param name="prefix">prefix to id</param>
        /// <param name="fillNumber">last sequence number</param>
        /// <param name="fillChar">char to fill on sequence number</param>
        /// <param name="sequence">sequence length</param>
        /// <returns>formated sequence number</returns>
        public static String FillSequence(String prefix, int fillNumber, String fillChar, int sequence)
        {
            String result = prefix;
            int realFill = fillNumber - (prefix + sequence).Length;
            for (var x = 1; x <= realFill; x++)
            {
                result += fillChar;
            }
            result += sequence;
            return result;
        }
    }
}
