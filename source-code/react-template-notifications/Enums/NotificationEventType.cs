using System.ComponentModel;

namespace react_template_notifications.Enums
{
    public enum NotificationEventType
    {
        [Description("system")]
        System,
        [Description("template")]
        Template,
        [Description("manual")]
        Manual
    }
}
