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
            DeepMorphyService deepMorphyService = new DeepMorphyService();
            deepMorphyService.Init();
            var words = File.ReadAllLines(path);
            var dictionary = deepMorphyService.GetBestGramKeysOfWords(words);
            if (words.Length != 0)
            {
                foreach (var word in dictionary)
                {
                    _db.Add(new WordsTableModel()
                    {
                        Word = word.Key, 
                        PartOfSpeech = word.Value["чр"]
                    });
                }
            }
            _db.SaveChanges();
            _db.Dispose();
        }
    }
}