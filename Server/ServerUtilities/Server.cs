using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerDB.ServerUtilities
{
    internal static class Server
    {
        private const int CHUNK_SIZE = 1024;// Розмір порції при передачі даних
        internal const char SEPARATOR = '¤';// Роздільник
        private static TcpListener serverSocket;
        private static bool serverIsRunning = false;

        private static void Send(string message, NetworkStream stream)
        {// Метод відправляє байти в потоці порціями
            byte[] bytes = Encoding.UTF8.GetBytes(message);
            int offset = 0;
            while (offset < bytes.Length)
            {// Поки не дійшли до кінця
                // Розмір поточної порції
                int currentChunkSize = Math.Min(bytes.Length - offset, CHUNK_SIZE);

                // Записуємо в потік байти та зміщуємо offset
                stream.Write(bytes, offset, currentChunkSize);
                offset += currentChunkSize;
            }
        }
        private static async Task<string> ReadAsync(NetworkStream stream)
        {// Метод зчитує байти від серверу
            List<byte> allBytes = new List<byte>();
            byte[] buffer = new byte[CHUNK_SIZE];
            int bytesRead;

            do
            {// Додаємо до списку масив байтів
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                allBytes.AddRange(buffer.Take(bytesRead));
            } while (stream.DataAvailable);

            return Encoding.UTF8.GetString(allBytes.ToArray());
        }
        private static async Task ProcessClientAsync(TcpClient clientSocket)
        {// Метод, який асинхронно виконує запити клієнтів
            try
            {
                NetworkStream clientStream = clientSocket.GetStream();
                byte[] bytes = new byte[CHUNK_SIZE];// Зчитуємо дані клієнта
                string query = await ReadAsync(clientStream);

                if (query.StartsWith("SELECT"))
                {// Якщо потрібно повернути результат
                    DataTable dt = DataBase.ExecuteReturnQuery(query);// Отримуємо таблицю потрібних даних

                    // Відправлення одного рядку даних через роздільник
                    string message = DataTableToString(dt);

                    Send(message, clientStream);
                }
                else// Виконуємо запит
                    DataBase.ExecuteQuery(query);

                await clientStream.FlushAsync();
            }
            finally
            { clientSocket.Close(); }
        }
        private static string DataTableToString(DataTable dt)
        {// Метод, який перетворює дані з DataTable на string, з роздільником
            string res = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                {
                    // Записуємо елемент
                    res += dt.Rows[i].ItemArray[j].ToString();

                    // Якщо не останній елемент, то додаємо роздільник
                    if (i != dt.Rows.Count - 1 || j != dt.Rows[i].ItemArray.Length - 1)
                        res += SEPARATOR;
                }
            return res;
        }

        internal static async Task StartAsync()
        {// Метод запускає сервер
            serverSocket = new TcpListener(System.Net.IPAddress.Any, 7124);
            serverSocket.Start();
            serverIsRunning = true;

            while (serverIsRunning)
            {// Очікуємо клієнта
                TcpClient clientSocket = await serverSocket.AcceptTcpClientAsync();
                _ = ProcessClientAsync(clientSocket);
            }
        }

        internal static void Stop()
        {// Метод зупиняє сервер
            serverIsRunning = false;
            serverSocket?.Stop();
        }
    }
}