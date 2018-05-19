using System;
using Web.Entities.Domain.Logs.Enums;

namespace Web.Entities.Domain.Logs
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type {get;set;}
        public string Entity { get; set; }
        public string User { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
}
