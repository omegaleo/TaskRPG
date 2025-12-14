using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskRPG.Core.Models;

namespace TaskRPG.Core.Http
{
    public class TaskRpgApiClient : HttpClient
    {
        public TaskRpgApiClient(string baseUrl, string apiKey, string apiSecret)
        {
            BaseAddress = new System.Uri(baseUrl);
            DefaultRequestHeaders.Add("Accept", "application/json");
            
            DefaultRequestHeaders.Add("X-API-KEY", apiKey);
            DefaultRequestHeaders.Add("X-API-SECRET", apiSecret);
        }
        
        public async Task<PlayerData?> GetPlayerDataAsync(string id)
        {
            var request =  await GetAsync($"/api/playerdata/{id}");

            if (!request.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve player data. Status code: {request.StatusCode} - {request.ReasonPhrase}");
            }
            
            var playerData = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PlayerData>(playerData) ?? null;
        }
        
        public async Task<Equipment?> GetEquipmentAsync(string id)
        {
            var request =  await GetAsync($"/api/equipment/{id}");

            if (!request.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve equipment data. Status code: {request.StatusCode} - {request.ReasonPhrase}");
            }
            
            var equipmentData = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Equipment>(equipmentData) ?? null;
        }
        
        public async Task<List<Equipment>?> GetAllEquipmentAsync()
        {
            var request =  await GetAsync($"/api/equipment");

            if (!request.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrieve equipment data. Status code: {request.StatusCode} - {request.ReasonPhrase}");
            }
            
            var equipmentData = await request.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Equipment>>(equipmentData) ?? null;
        }
        
        public async Task<bool> UpdatePlayerDataAsync(PlayerData playerData)
        {
            var jsonContent = JsonConvert.SerializeObject(playerData);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            
            var response = await PutAsync($"/api/playerdata/{playerData.Id}", content);
            
            return response.IsSuccessStatusCode;
        }
        
        public async Task<bool> AddEquipmentAsync(Equipment equipment)
        {
            var jsonContent = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            
            var response = await PostAsync($"/api/equipment", content);
            
            return response.IsSuccessStatusCode;
        }
    }
}