using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dotz.Fidelity.CrossCutting
{
    public class Result
    {
        protected Result()
        {
            Messages = new HashSet<string>();
        }

        protected Result(string message)
            : this()
        {
            Messages.Add(message);
        }

        protected Result(IEnumerable<string> messages)
            : this()
        {
            Messages.UnionWith(messages);
        }

        public ISet<string> Messages { get; }

        [JsonIgnore] public bool IsFailure => !IsSuccess;

        [JsonIgnore] public bool IsSuccess => Messages.Count == 0;

        public static Result Ok() => new Result();

        public static Result Fail(string message) => new Result(message);

        public static Result Fail(IEnumerable<string> messages) => new Result(messages);
    }
}
