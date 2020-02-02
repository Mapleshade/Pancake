using System;
using System.Linq;
using Pancake.Configurations;
using Pancake.Contexts;

namespace Pancake.Services
{
    public class RandomWordsService
    {
        public bool IsInitialized { get; private set; }
        private PancakeContext _db;
        private readonly Random _random = new Random();
        private int _randomInt;
        
        public void Init(PancakeConfiguration configuration)
        {
            if (!IsInitialized)
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
            else
            {
                Console.WriteLine($"RandomWordsService already initialized!");
            }
            
        }
        
        public string GetRandomWord()
        {
            if (IsInitialized)
            {
                var count = _db.Words.Count();
                _randomInt = _random.Next(0, count);
                return _db.Words.ToArray()[_randomInt].Word;
            } 
            Console.WriteLine($"RandomWordsService isn't initialized!");
            return string.Empty;
        }
        
        public string GetRandomWordWithStartStr(string str) //todo: добавить поддержку регистра
        {
            if (IsInitialized)
            {
                var wordsFromDb = _db.Words.Where(x => x.Word.StartsWith(str));
                if (!wordsFromDb.Any())
                {
                    Console.WriteLine($"There are no words in the database starting with {str}!");
                    return string.Empty;
                }
                _randomInt = _random.Next(0, wordsFromDb.Count());
                return wordsFromDb.ToArray()[_randomInt].Word;
            }
            Console.WriteLine($"RandomWordsService isn't initialized!");
            return string.Empty;
        }

        public void Dispose()
        {
            if (IsInitialized)
            {
                try
                {
                    _db.Dispose();
                    IsInitialized = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error disconnecting to database: {e}");
                    throw;
                }
            }
            else
            {
                Console.WriteLine("RandomWordsService isn't initialized!");
            }
        }
    }
}