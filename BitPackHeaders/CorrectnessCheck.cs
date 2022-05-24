using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace BitPackHeaders
{
    internal static class CorrectnessCheck
    {
        public static void Fields(IEnumerable<HeaderNames> values)
        {
            FieldHeaders obj = new FieldHeaders();
            foreach (HeaderNames name in values)
            {
                if (obj.TryGetValue(name, out _))
                {
                    throw new Exception("Shouldn't be set");
                }

                string str = name.ToString() + "_value";

                obj.Set(name, str);

                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                if (!object.ReferenceEquals(str, val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);
                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }

            foreach (HeaderNames name in values)
            {
                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                string str = name.ToString() + "_value";

                if (!str.Equals(val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);

                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }
        }

        public static void Dictionary(IEnumerable<HeaderNames> values)
        {
            DictionaryHeaders obj = new DictionaryHeaders();
            foreach (HeaderNames name in values)
            {
                if (obj.TryGetValue(name, out _))
                {
                    throw new Exception("Shouldn't be set");
                }

                string str = name.ToString() + "_value";

                obj.Set(name, str);

                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                if (!object.ReferenceEquals(str, val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);
                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }

            foreach (HeaderNames name in values)
            {
                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                string str = name.ToString() + "_value";

                if (!str.Equals(val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);

                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }
        }

        public static void Array(IEnumerable<HeaderNames> values)
        {
            ArrayHeaders obj = new ArrayHeaders();
            foreach (HeaderNames name in values)
            {
                if (obj.TryGetValue(name, out _))
                {
                    throw new Exception("Shouldn't be set");
                }

                string str = name.ToString() + "_value";

                obj.Set(name, str);

                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                if (!object.ReferenceEquals(str, val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);
                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }

            foreach (HeaderNames name in values)
            {
                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                string str = name.ToString() + "_value";

                if (!str.Equals(val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);

                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }
        }

        public static void Packed(IEnumerable<HeaderNames> values)
        {
            List<HeaderNames> alreadyHandled = new List<HeaderNames>();

            PackedHeaders obj = new PackedHeaders();
            foreach (HeaderNames name in values)
            {
                foreach(HeaderNames prev in alreadyHandled)
                {
                    if(!obj.TryGetValue(prev, out string? prevVal))
                    {
                        throw new Exception("Should be set");
                    }

                    if(!prevVal.Equals(prev+"_value"))
                    {
                        throw new Exception("Unexpected value");
                    }
                }

                if (obj.TryGetValue(name, out _))
                {
                    throw new Exception("Shouldn't be set");
                }

                string str = name.ToString() + "_value";

                obj.Set(name, str);

                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                if (!object.ReferenceEquals(str, val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);
                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }

                alreadyHandled.Add(name);
            }

            foreach (HeaderNames name in values)
            {
                if (!obj.TryGetValue(name, out string val))
                {
                    throw new Exception("Should be set");
                }

                string str = name.ToString() + "_value";

                if (!str.Equals(val))
                {
                    throw new Exception("Unexpected value");
                }

                string strByName = (string)obj.GetType().GetProperty(name.ToString()).GetValue(obj);

                if (!object.ReferenceEquals(strByName, val))
                {
                    throw new Exception("Unexpected value");
                }
            }
        }
    }
}