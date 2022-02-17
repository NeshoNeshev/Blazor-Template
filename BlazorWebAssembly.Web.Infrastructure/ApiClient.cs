using System.Net.Http;

namespace BlazorWebAssembly.Web.Infrastructure
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        //private readonly IApplicationState applicationState;
        //private readonly IJSRuntime jsRuntime;

        //public ApiClient(HttpClient httpClient, IApplicationState applicationState, IJSRuntime jsRuntime)
        //{
        //    this.httpClient = httpClient;
        //    //this.applicationState = applicationState;
        //    //this.jsRuntime = jsRuntime;
        //}

        //public Task<ApiResponse<DemoResponseModel>> GetIndex() =>
        //    this.GetResponse<DemoResponseModel>("api/Home/GetIndex");

        //public Task<ApiResponse<DemoResponseModel>> GetDemo() =>
        //    this.GetResponse<DemoResponseModel>("api/Demo/GetDemo");

        //public Task<ApiResponse<ApplicationStartResponseModel>> ApplicationStart() =>
        //    this.GetResponse<ApplicationStartResponseModel>("api/Application/Start");

        //public Task<ApiResponse<ApplicationStopResponseModel>> ApplicationStop(ApplicationStopRequestModel request) =>
        //    this.PostJson<ApplicationStopRequestModel, ApplicationStopResponseModel>("api/Application/Stop", request);


        //public Task<ApiResponse<UserRegisterResponseModel>> UserRegister(UserRegisterRequestModel request) =>
        //    this.PostJson<UserRegisterRequestModel, UserRegisterResponseModel>("api/Account/Register", request);

        //public async Task<ApiResponse<UserLoginResponseModel>> UserLogin(UserLoginRequestModel request)
        //{
        //    try
        //    {

        //        var response = await this.httpClient.PostAsync(
        //                           "api/account/login",
        //                           new FormUrlEncodedContent(
        //                               new List<KeyValuePair<string, string>>
        //                               {
        //                                   new KeyValuePair<string, string>("email", request.Email),
        //                                   new KeyValuePair<string, string>("password", request.Password),
        //                               }));

        //        var responseString = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            return new ApiResponse<UserLoginResponseModel>(new ApiError("Server error " + (int)response.StatusCode, responseString));
        //        }

        //        var responseObject = JsonSerializer.Deserialize<UserLoginResponseModel>(responseString);
        //        return new ApiResponse<UserLoginResponseModel>(responseObject);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponse<UserLoginResponseModel>(new ApiError("HTTP Client", ex.Message));
        //    }
        //}

        //private async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
        //{
        //    if (this.applicationState.IsLoggedIn)
        //    {
        //        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
        //    }
        //    else if (await this.jsRuntime.ReadToken() != null)
        //    {
        //        // This is workaround for https://github.com/aspnet/Blazor/issues/1185
        //        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
        //    }

        //    try
        //    {
        //        var response = await this.httpClient.PostAsJsonAsync(url, request);
        //        var responseObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
        //        return responseObject;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
        //    }
        //}

        //private async Task<ApiResponse<T>> GetResponse<T>(string url)
        //{
        //    if (this.applicationState.IsLoggedIn)
        //    {
        //        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
        //    }
        //    else if (await this.jsRuntime.ReadToken() != null)
        //    {
        //        // This is workaround for https://github.com/aspnet/Blazor/issues/1185
        //        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
        //    }

        //    try
        //    {
        //        return await this.httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponse<T>(new ApiError("HTTP Client", ex.Message));
        //    }
        //}
    }
}
