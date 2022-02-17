namespace BlazorWebAssembly.Web.Infrastructure.ApiResponse
{
    public static class ApiResponseExtensions
    {
        public static ApiResponse<T> ToApiResponse<T>(this T data)
        {
            return new ApiResponse<T>(data);
        }
    }
}
