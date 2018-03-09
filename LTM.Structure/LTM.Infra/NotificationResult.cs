using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Infra
{
    public class NotificationResult
    {
        public bool IsValid { get; set; }
        public object Data { get; set; }
        public IList<NotificationMessage> Messages { get; set; }
        public IList<NotificationMessage> Errors { get; set; }

        public void AddError(object message)
        {
            Errors.Add(new NotificationMessage()
            {
                Type = NotificationMessageType.Error,
                Message = message != null ? message.ToString() : "Unspecified error"
            });
        }

        public string GetErrors()
        {
            return Errors != null ? string.Join(", ", Errors) : "";
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
