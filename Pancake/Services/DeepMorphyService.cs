using System;
using System.Collections.Generic;
using System.Linq;
using DeepMorphy;

namespace Pancake.Services
{
    public class DeepMorphyService
    {
        public bool IsInitialized { get; private set; }
        private MorphAnalyzer _morph;

        public void Init()
        {
            _morph = new MorphAnalyzer();
            IsInitialized = true;
        }

        public IEnumerable<MorphInfo> GetMorphInfoOfWords(IEnumerable<string> str)
        {
            return _morph.Parse(str);
        }
        
        public MorphInfo GetMorphInfoOfWord(string str)
        {
            return _morph.Parse(new[] {str}).First();
        }

        public Dictionary<string, Tag> GetBestGramKeysOfWords(IEnumerable<string> str)
        {
            var morphInfos = _morph.Parse(str);

            Dictionary<string, Tag> dictionary = new Dictionary<string, Tag>();
            foreach (var info in morphInfos)
            {
                if(!dictionary.ContainsKey(info.Text))
                    dictionary.Add(info.Text, info.BestTag);
            }
            return dictionary;
        }
    }
}