using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace F1Pontszamitos_S6.Shared.Utils
{
    public class FileReader
    {

        private readonly HttpClient _httpClient;
        public FileReader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Dictionary<string, string>> ReadJsonToDict(string filepath)
        {


            var json = await _httpClient.GetStringAsync(filepath);

            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            return result;

        }

    }
}
