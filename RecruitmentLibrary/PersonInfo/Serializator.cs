using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RecruitmentLibrary.PersonInfo
{
    public static class Serializator
    {// Статичний клас для серіалізації
        private static void Encrypt(string key, string path)
        {// Метод XOR-шифрування
            byte[] keyBytes = Convert.FromBase64String(key);// Ключ

            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {// Відкриваємо файл для зчитування та запису даних
                // Буфер зчитаних даних
                byte[] buffer = new byte[4096];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {// Зчитуємо блоками дані
                    for (int i = 0; i < bytesRead; i++)// Застосовуємо XOR з ключем до кожного байта
                        buffer[i] = (byte)(buffer[i] ^ keyBytes[i % keyBytes.Length]);

                    // Переміщаємо позицію в файлі на початок блока, щоб записати зашифровані дані
                    fileStream.Seek(-bytesRead, SeekOrigin.Current);

                    // Записуємо зашифровані дані назад у файл
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        public static void Serialize<T>(T entity, string path, string key) where T : class
        {// Серіалізація
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // Приховуємо файл
                File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, entity);

                stream.Close();// Закриваємо потік
                Encrypt(key, path);// Шифруємо дані
            }
        }
        public static T Deserialize<T>(string path, string key) where T : class
        {// Десеріалізація
            try
            {
                Encrypt(key, path);// Розшифровуємо дані
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();// Зчитуємо дані в об’ект
                    T entity = (T)formatter.Deserialize(stream);

                    stream.Close();// Закриваємо потік
                    Encrypt(key, path);// Шифруємо дані

                    return entity;
                }
            }
            catch
            { return null; }
        }
        public static bool SerializationFileExists(string path) => File.Exists(path);
        public static void DeleteSerializationFile(string path)
        {// Метод видаляє файл серіалізації
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}