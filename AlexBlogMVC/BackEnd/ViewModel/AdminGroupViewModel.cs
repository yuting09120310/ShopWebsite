namespace AlexBlogMVC.BackEnd.ViewModel
{
    public class AdminGroupViewModel
    {
        public long GroupNum { get; set; }

        public string? GroupName { get; set; }

        public string? GroupInfo { get; set; }

        public bool? GroupPublish { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? Creator { get; set; }

        public DateTime? EditTime { get; set; }

        public long? Editor { get; set; }

        public string? Ip { get; set; }

        public string? CreatorName { get; set; }

        public string? EditorName { get; set; }

    }
}
