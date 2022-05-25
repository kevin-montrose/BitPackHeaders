using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace BitPackHeaders
{
    internal static class CorrectnessCheck
    {
        public static void Fields(IEnumerable<HeaderNames> values)
        {
            List<HeaderNames> alreadyHandled = new List<HeaderNames>();

            FieldHeaders obj = new FieldHeaders();
            foreach (HeaderNames name in values)
            {
                List<HeaderNames> keys1 = new List<HeaderNames>();
                foreach (HeaderNames key in obj)
                {
                    keys1.Add(key);
                }

                List<HeaderNames> keys2 = new List<HeaderNames>();
                foreach (HeaderNames key in obj.Enumerable())
                {
                    keys2.Add(key);
                }

                if (!alreadyHandled.OrderBy(x => x).SequenceEqual(keys1.OrderBy(x => x)))
                {
                    throw new Exception("Keys didn't match expected");
                }

                if (!alreadyHandled.OrderBy(x => x).SequenceEqual(keys2.OrderBy(x => x)))
                {
                    throw new Exception("Keys didn't match expected");
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

        public static void Dictionary(IEnumerable<HeaderNames> values)
        {
            List<HeaderNames> alreadyHandled = new List<HeaderNames>();

            DictionaryHeaders obj = new DictionaryHeaders();
            foreach (HeaderNames name in values)
            {
                List<HeaderNames> keys = new List<HeaderNames>();
                foreach (HeaderNames key in obj)
                {
                    keys.Add(key);
                }

                if (!alreadyHandled.OrderBy(x => x).SequenceEqual(keys.OrderBy(x => x)))
                {
                    throw new Exception("Keys didn't match expected");
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

        public static void Array(IEnumerable<HeaderNames> values)
        {
            List<HeaderNames> alreadyHandled = new List<HeaderNames>();

            ArrayHeaders obj = new ArrayHeaders();
            foreach (HeaderNames name in values)
            {
                List<HeaderNames> keys = new List<HeaderNames>();
                foreach (HeaderNames key in obj)
                {
                    keys.Add(key);
                }

                List<HeaderNames> alreadyHandledInOrder = alreadyHandled.OrderBy(x => x).ToList();
                List<HeaderNames> keysInOrder = keys.OrderBy(x => x).ToList();
                if (!alreadyHandledInOrder.SequenceEqual(keysInOrder))
                {
                    throw new Exception("Keys didn't match expected");
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

        public static void Packed(IEnumerable<HeaderNames> values)
        {
            List<HeaderNames> alreadyHandled = new List<HeaderNames>();

            PackedHeaders obj = new PackedHeaders();
            foreach (HeaderNames name in values)
            {
                foreach (HeaderNames prev in alreadyHandled)
                {
                    if (!obj.TryGetValue(prev, out string? prevVal))
                    {
                        throw new Exception("Should be set");
                    }

                    if (!prevVal.Equals(prev + "_value"))
                    {
                        throw new Exception("Unexpected value");
                    }
                }

                List<HeaderNames> keys = new List<HeaderNames>();
                foreach (HeaderNames key in obj)
                {
                    keys.Add(key);
                }

                if (!alreadyHandled.OrderBy(x => x).SequenceEqual(keys.OrderBy(x => x)))
                {
                    throw new Exception("Keys didn't match expected");
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