using Core.Utilities.Message.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Utilities.Message.Concrete
{
    public class SmsManager : ISmsServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public SmsManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<bool> SendOtpSmsAsync(string phoneNumber, string otp)
        {
            try
            {
                var apiUrl = _configuration["SMS:Uri"];

                var data = new
                {
                    Message = $"Təsdiqləmək üçün OTP kodunu daxil edin: {otp}",
                    Receivers = new[] { phoneNumber },
                    SendDate = DateTime.UtcNow.AddHours(4).ToString("yyyyMMdd HH:mm"),
                    ExpireDate = DateTime.UtcNow.AddHours(4).AddMinutes(3).ToString("yyyyMMdd HH:mm"),
                    Username = _configuration["SMS:Username"],
                    Password = _configuration["SMS:Password"]
                };

                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using var httpClient = new HttpClient();
                var response = await httpClient.PostAsync(apiUrl, content);

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response from API: " + responseContent);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
