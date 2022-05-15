using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApiProj.Response
{
    public class Response<T>
    {
        public List<string> Errors { get; set; }
        public bool IsSuccess { get; set; }
        [JsonProperty]
        public T Entity { get; set; }
        [JsonProperty]
        public List<T> Entities { get; set; }

        public Response()
        {
            IsSuccess = true;
            Errors = new List<string>();
            Entities = new List<T>();
        }

        public Response(T entity) : this()
        {
            Entity = entity;
        }

        public Response(List<T> entities) : this()
        {
            Entities = entities;
        }

        public Response(List<string> Errors) : this()
        {
            Entities = new List<T>();
            this.Errors = Errors;
        }

        public void SetErrors(List<string> errors)
        {
            Entities = null;
            IsSuccess = false;
            Errors = errors;
        }

        public void AddError(string error)
        {
            Entities = null;
            IsSuccess = false;
            Errors.Add(error);
        }
    }
}
