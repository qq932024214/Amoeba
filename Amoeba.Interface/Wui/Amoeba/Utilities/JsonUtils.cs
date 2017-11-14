﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Omnius.Base;
using Omnius.Io;

namespace Amoeba.Interface
{
    static class JsonUtils
    {
        public static T Clone<T>(T item)
        {
            using (var stream = new BufferStream(BufferManager.Instance))
            {
                JsonUtils.Save(stream, item);
                stream.Seek(0, SeekOrigin.Begin);

                return JsonUtils.Load<T>(stream);
            }
        }

        public static T Load<T>(Stream stream)
        {
            try
            {
                using (var streamReader = new StreamReader(new WrapperStream(stream, true), new UTF8Encoding(false)))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var serializer = new JsonSerializer();
                    serializer.MissingMemberHandling = MissingMemberHandling.Ignore;

                    serializer.TypeNameHandling = TypeNameHandling.None;
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    serializer.ContractResolver = new CustomContractResolver();

                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
            catch (Exception e)
            {
                Log.Warning(e);
            }

            return default(T);
        }

        public static void Save<T>(Stream stream, T value)
        {
            try
            {
                using (var streamWriter = new StreamWriter(new WrapperStream(stream, true), new UTF8Encoding(false)))
                using (var jsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    var serializer = new JsonSerializer();

                    serializer.TypeNameHandling = TypeNameHandling.None;
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter());
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    serializer.ContractResolver = new CustomContractResolver();

                    serializer.Serialize(jsonTextWriter, value);
                }
            }
            catch (Exception e)
            {
                Log.Warning(e);
            }
        }

        class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                if (objectType.GetInterfaces().Any(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
                {
                    return base.CreateArrayContract(objectType);
                }

                if (System.Attribute.GetCustomAttributes(objectType).Any(n => n is DataContractAttribute))
                {
                    var objectContract = base.CreateObjectContract(objectType);
                    objectContract.DefaultCreatorNonPublic = false;
                    objectContract.DefaultCreator = () => FormatterServices.GetUninitializedObject(objectContract.CreatedType);

                    return objectContract;
                }

                return base.CreateContract(objectType);
            }
        }
    }
}
