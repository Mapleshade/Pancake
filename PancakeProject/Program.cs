using Pancake.Configurations;
using Pancake.Services;

namespace PancakeProject
{
    class Program
    {
        private static string _path = "C:\\Users\\MapleshadeSF\\Documents\\Pancake\\PancakeProject\\pldf-win.txt";

        private static string _connectionString =
            "Host=localhost;Database=Words;Username=postgres;Password=marshmallow";

        static void Main(string[] args)
        {
            // var db = new PancakeContext();
            // var words = File.ReadAllLines();


            DataBaseService dataBaseService = new DataBaseService();
            dataBaseService.Init(new PancakeConfiguration()
            {
                DBConnectionString = _connectionString
            });
            dataBaseService.AddWordsToDataBaseFromFile(_path);
            // foreach (var word in words)
            // {
            //     db.Add(new WordsTableModel() {Word = word});
            // }
            //
            // db.SaveChanges();
            // db.Dispose();
        }
    }
}