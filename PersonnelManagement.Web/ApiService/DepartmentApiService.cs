using Newtonsoft.Json;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Web.ApiService
{
   
    public class DepartmentApiService
    {
        public readonly HttpClient _httpClient;
        public DepartmentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            IEnumerable<DepartmentDto> departmentDtos;
           var response= await _httpClient.GetAsync("Department");
            if (response.IsSuccessStatusCode)
            {
                departmentDtos = JsonConvert.DeserializeObject<IEnumerable<DepartmentDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                departmentDtos = null;
            }
            return departmentDtos;
        }

        public async Task<DepartmentDto> AddAsync(DepartmentDto departmentDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(departmentDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Department", stringContent);

            if (response.IsSuccessStatusCode)
            {
                departmentDto = JsonConvert.DeserializeObject<DepartmentDto>(await response.Content.ReadAsStringAsync());
                return departmentDto;
            }
            else
            {
                return null;
            }
        }
        public async Task<UpdateDepartmentDto> GetByIdUpdateDtoAsync(int Id)
        {

            var response = await _httpClient.GetAsync($"Department/{Id}");
            if (response.IsSuccessStatusCode)
            {
                UpdateDepartmentDto updateDepartmentDto =JsonConvert.DeserializeObject<UpdateDepartmentDto>(await response.Content.ReadAsStringAsync());
                return updateDepartmentDto;
            }
            else
            {
                return null;
            }
        }
        public async Task<DepartmentDto> GetByIdAsync(int Id)
        {

            var response = await _httpClient.GetAsync($"Department/{Id}");
            if (response.IsSuccessStatusCode)
            {
                DepartmentDto departmentDto = JsonConvert.DeserializeObject<DepartmentDto>(await response.Content.ReadAsStringAsync());
                return departmentDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<UpdateDepartmentDto> Update(UpdateDepartmentDto updateDepartmentDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateDepartmentDto), Encoding.UTF8, "application/json");
            var response=await _httpClient.PutAsync("Department", stringContent);

            if (response.IsSuccessStatusCode)
            {
                updateDepartmentDto = JsonConvert.DeserializeObject<UpdateDepartmentDto>( await response.Content.ReadAsStringAsync());
                return updateDepartmentDto;
            }
            else
            {
                return null;
            }
        }

        public async Task Delete(int Id)
        {
            await _httpClient.DeleteAsync($"Department/{Id}");
        }
}
}
