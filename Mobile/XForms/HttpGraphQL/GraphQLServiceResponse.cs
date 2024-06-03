using System.Collections.Generic;
using GraphQL;
using Newtonsoft.Json;

namespace XForms.HttpREST
{
    public class GraphQLServiceResponse<T>
    {

        [JsonProperty("errors")]
        public IEnumerable<GraphQLError> Errors { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        public GraphQLServiceResponse()
        {

        }

        public GraphQLServiceResponse(T data)
        {
            this.Data = data;
        }

        public GraphQLServiceResponse(IEnumerable<GraphQLError> errors)
        {
            this.Errors = errors;
        }


        public GraphQLServiceResponse(T data, IEnumerable<GraphQLError> errors)
        {
            this.Data = data;
            this.Errors = errors;
        }
    }

    public partial class Error
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("extensions")]
        public Extensions Extensions { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }

        [JsonProperty("path")]
        public List<string> Path { get; set; }
    }

    public partial class Extensions
    {
        [JsonProperty("category")]
        public string Category { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("line")]
        public long Line { get; set; }

        [JsonProperty("column")]
        public long Column { get; set; }
    }
}