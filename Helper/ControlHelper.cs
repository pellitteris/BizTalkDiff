using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsys.EAI.BizTalkUtilities.Helper
{
    public class StandardBindingElement
    {
        public string Key { get; set; }
        public string Key2
        {
            get
            {
                return Key.Substring(0, 1).ToUpper() + Key.Substring(1, Key.Length - 1);
            }
        }
        public string Value { get; set; }
        public bool Update { get; set; }

        public StandardBindingElement()
        {

        }
    }

    public static class ControlHelper
    {
        public static List<StandardBindingElement> CreateStandardBindingElementList()
        {
            try
            {
                List<StandardBindingElement> List = new List<StandardBindingElement>();
                List.Add(new StandardBindingElement { Key = "closeTimeout", Value = "00:01:00", Update = false });
                List.Add(new StandardBindingElement { Key = "openTimeout", Value = "00:01:00", Update = false });
                List.Add(new StandardBindingElement { Key = "receiveTimeout", Value = "00:10:00", Update = false });
                List.Add(new StandardBindingElement { Key = "sendTimeout", Value = "00:10:00", Update = false });

                return List;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void SetPropertyValues(this List<StandardBindingElement> sbel, string key, string value, bool update)
        {
            try
            {
                int index = sbel.FindIndex(x => x.Key == key);
                sbel[index].Value = value;
                sbel[index].Update = update;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static string GetPropertyValues(this List<StandardBindingElement> sbel, string key)
        {
            try
            {
                return sbel.Where(x => x.Key == key).FirstOrDefault().Value;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
