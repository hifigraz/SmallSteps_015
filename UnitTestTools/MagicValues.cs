using System;
using System.Collections.Generic;

namespace UnitTestTools
{
    public class MagicValues
    {
        private static string _persistant_uid = null;

        private static string PersistantUid
        {
            get
            {
                if (_persistant_uid == null)
                {
                    _persistant_uid = "Robert";
                    try
                    {
                        string origin = TestTools.RunCommand("git", "remote get-url origin");
                        Uri origin_uri = new Uri(origin);
                        _persistant_uid = origin_uri.LocalPath;
                    } catch (Exception)
                    {
                        // using old
                    }
                }
                return _persistant_uid;
            }
        }

        public static uint MagicUINT
        {
            get
            {
                uint return_value = 0;
                foreach (byte item in PersistantUid)
                {
                    return_value += item;
                }
                return return_value;
            }
        }
        public static int MagicINT
        {
            get
            {
                int return_value = 10;
                bool negative = true;
                foreach(byte item in PersistantUid)
                {
                    return_value += item;
                    negative = !negative;
                }
                if (negative)
                {
                    return -return_value;
                }
                return return_value;
            }
        }
        public static string MagicName
        {
            get
            {
                int index = (int)MagicUINT % Names._names.Count;
                return Names._names[index];
            }
        }
        public static int MagicSMALL
        {
            get
            {
                if (PersistantUid.Length % 2 == 0)
                {
                    return PersistantUid.Length;
                }
                return -PersistantUid.Length;
            }
        }
        public static int MagicINT10
        {
            get
            {
                if (PersistantUid.Length % 2 == 0)
                {
                    return PersistantUid.Length % 10;
                }
                return -PersistantUid.Length % 10;
            }
        }
        public static uint MagicUSMALL
        {
            get
            {
                return (uint)PersistantUid.Length;
            }
        }
        public static uint MagicUINT10
        {
            get
            {
                return (uint)PersistantUid.Length % 10;
            }
        }
        public static string MagicString
        {
            get
            {
                return PersistantUid;
            }
        }
    }
}
