namespace SecondBrain.Models
{
    public class DateOfWeek
    {
        public DateOfWeek(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
}
