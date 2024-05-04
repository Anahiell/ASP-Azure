namespace ASP_SPU221_HMW.Models.Rest
{

    public class RestResponse
    {
        public RestStatus Status { get; set; } = new() { Code = 200, Message = "OK", IsOK = true };
        public RestMeta Meta { get; set; } = new();
        public Object Data { get; set; } = new();
    }
    public class RestStatus
    {
        public Int32 Code { get; set; }
        public String Message { get; set; } = "";
        public Boolean IsOK { get; set; }
    }
    public class RestMeta
    {
        public String Service { get; set; } = "";
        public Int32 Total { get; set; }
        public Int64 ServerTime { get; set; } = DateTime.Now.Ticks;
        public Dictionary<String, String> ReguestParameters { get; set; } = [];
    }

}
