using Newtonsoft.Json;
using System;

namespace ExceptionSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects
            };

            try
            {
                throw new ArgumentException();
            }
            catch (ArgumentException ex)
            {
                var exJson = JsonConvert.SerializeObject(ex);
                var exception = JsonConvert.DeserializeObject(exJson);

                Console.WriteLine(exception);
                Console.ReadLine();
            }
        }
    }
}
