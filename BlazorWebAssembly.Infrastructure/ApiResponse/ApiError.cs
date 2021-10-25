namespace BlazorWebAssembly.Infrastructure.ApiResponse
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(string item, string error)
        {
            this.Item = item;
            this.Error = error;
        }

        public string Item { get; set; }

        public string Error { get; set; }

        public override string ToString()
        {
            return $"{this.Item}: {this.Error}";
        }
    }
}
