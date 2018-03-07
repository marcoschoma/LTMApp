using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra
{
    public class NotificationResult
    {
        public bool IsValid { get; set; }
        public object Data { get; set; }
        public IEnumerable<NotificationMessage> Messages { get; set; }
        public IEnumerable<NotificationMessage> Errors { get; set; }

        public void AddError(object message)
        {
            throw new NotImplementedException();
        }

        public class NotificationMessage
        {
            public string Message { get; set; }
            public NotificationMessageType Type { get; set; }
        }

        public enum NotificationMessageType
        {
            Warning,
            Error
        }
    }
}
