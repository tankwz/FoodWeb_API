using System.Net;

namespace FoodWeb_API.Models
{
    public class ApiResponse
    {
        public ApiResponse() { 
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
