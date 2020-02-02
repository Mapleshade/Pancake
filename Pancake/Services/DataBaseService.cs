using System;
using System.IO;
using Pancake.Configurations;
using Pancake.Contexts;
using Pancake.Models;

namespace Pancake.Services
{
    public class DataBaseService //todo: дописать
    {
        public bool IsInitialized { get; private set; }
        private PancakeContext _db; //todo: подключение должно быть одно на все сервисы?

        public void Init(PancakeConfiguration configuration)
        {
            try
            {
                _db = new PancakeContext(configuration);
                IsInitialized = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to database: {e}");
                throw;
            }
        }

        public void AddWordsToDataBaseFromFile(string path)
        {
            var words = File.ReadAllLines(path);
            if (words.Length != 0)
            {
                foreach (var word in words)
                {
                    _db.Add(new WordsTableModel() {Word = word});
                }
            }
        }
    }
}