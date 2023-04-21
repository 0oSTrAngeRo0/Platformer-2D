//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Runtime.Serialization.Formatters.Binary;
//using UnityEngine;

//[System.AttributeUsage(System.AttributeTargets.Field)]
//public class CustomSerialization : System.Attribute { }

//public interface IAutoSerialization : ISerializationCallbackReceiver
//{
//    private static Dictionary<Type, FieldInfo[]> fieldDict;

//    static IAutoSerialization()
//    {
//        fieldDict = new Dictionary<Type, FieldInfo[]>();
//    }

//    private FieldInfo[] GetInfoData(Type type)
//    {
//        if (!fieldDict.ContainsKey(type))
//        {
//            var infos = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
//                Where(f => f.GetCustomAttribute<CustomSerialization>() != null).ToArray();
//            fieldDict.Add(type, infos);
//        }

//        return fieldDict[type];
//    }

//    byte[] Datas { get; set; }


//    void ISerializationCallbackReceiver.OnBeforeSerialize()
//    {
//        var fieldInfos = GetInfoData(GetType());

//        // 暂存所有数据
//        var databuffer = new object[fieldInfos.Length];
//        for (int i = 0; i < fieldInfos.Length; i++)
//        {
//            databuffer[i] = fieldInfos[i].GetValue(this);
//        }

//        // 序列化暂存数组
//        BinaryFormatter formatter = new BinaryFormatter();
//        using (MemoryStream ms = new MemoryStream())
//        {
//            formatter.Serialize(ms, databuffer);
//            Datas = ms.ToArray();
//            ms.Close();
//        }
//    }

//    void ISerializationCallbackReceiver.OnAfterDeserialize()
//    {
//        var fieldInfos = GetInfoData(GetType());
//        BinaryFormatter formatter = new BinaryFormatter();
//        object[] databuffer = null;
//        using (MemoryStream ms = new MemoryStream(Datas))
//        {
//            try
//            {
//                databuffer = formatter.Deserialize(ms) as object[];
//            }
//            catch (Exception)
//            {
//                Debug.LogWarning($"{GetType()}数据反序列化失败 数据丢失", this as UnityEngine.Object);
//                Datas = null;
//            }

//            ms.Close();
//        }

//        if (databuffer == null) return;
//        // 反序列化所有数据
//        for (int i = 0; i < databuffer.Length; i++)
//        {
//            if (databuffer[i] == null) continue;
//            fieldInfos[i].SetValue(this, databuffer[i]);
//        }
//    }
//}
