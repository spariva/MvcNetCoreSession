﻿using MvcNetCoreSession.Helpers;
using Newtonsoft.Json;
using System.Text.Json;

namespace MvcNetCoreSession.Extensions
{
    public static class SessionExtension
    {
        public static T GetObject<T>(this ISession session, string key)
        {
            string json = session.GetString(key);
            if (json == null) 
            {
                return default(T);
            }else
            {
                //T data = HelperJsonSession.DeserializeObject<T>(json);
                T data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public static void SetObject(this ISession session, string key, object value) 
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }
    }
}
