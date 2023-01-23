 using Newtonsoft.Json;
using New_App.models;

namespace New_App.serviece
{
    public class ApiiServeice
    {
        public async Task<Root> GetNews(string categoryname)//ask 
        {
            var httpClien = new HttpClient();//ask 
         
            var response = await httpClien.GetStringAsync("https://gnews.io/api/v4/top-headlines?token=bbc571f8064578c30c4d4e5b8f3aee25&topic=breaking-news&lang=en&topic=" + categoryname.ToLower());
           return JsonConvert.DeserializeObject<Root>(response);

        }
    }
}
