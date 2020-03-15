using System;

namespace DatesTestTask.Core
{
    public interface IDatesRange
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class DatesRange : IDatesRange
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
