using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using UnvisualComponentsAlesa.Object;

namespace UnvisualComponentsAlesa
{
    //8, 11,23
    //8 - Хранилище данных (store). Данные хранятся в бинарном файле. 
    //Проверять, что тип передаваемых данных настроен для работы с
    //бинарным форматом(у класса указан требуемый атрибут). Есть два
    //публичных метода – получить данные и сохранить данные.

    public class StorageComponent : Component
    {
        public string filename { get; set; }

        private class Object<T> { }
        ///<summary>
        ///Метод получения данных и проверки наличия атрибутов сериализации
        ///</summary>
        public void GetData <T>(T objMy)
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<SerializableAttribute>();
        }

        ///<summary>
        ///Метод сохранения данных
        ///</summary>
        public void SaveData <T>(T objMy)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    // 2. Связать поток fs с экземпляром bw:
                    // bw -> fs -> "abc.bin"
                    using (BinaryWriter writer = new BinaryWriter(fs, Encoding.Default))
                    {
                        // записываем в файл значение каждого поля структуры
                        int j = 0;
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            writer.Write(prop.GetValue(objMy).ToString());
                            j++;
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Ошибка сохранения");
                }
            }
        }

        private void GetDataInNormalFormat <T>(T objectMy)
        {
            //int count
            //string[] objValue = new string[];
            //int j = 0;
            //foreach (var prop in typeof(T).GetProperties())
            //{
            //    objValue[j] = prop.GetValue(objectMy).ToString();
            //    Console.WriteLine(prop.Name + prop.GetValue(objectMy));
            //    j++;
            //}
        }
    }
}
