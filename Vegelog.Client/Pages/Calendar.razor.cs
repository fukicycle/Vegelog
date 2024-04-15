namespace Vegelog.Client.Pages
{
    public partial class Calendar
    {
        private List<(string, int)> _days = new List<(string, int)>();
        private DateTime _currentDate = DateTime.Today;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CreateCalendar();
        }

        private void NextButtonOnClick()
        {
            _currentDate = _currentDate.AddMonths(1);
            CreateCalendar();
        }

        private void PrevButtonOnClick()
        {
            _currentDate = _currentDate.AddMonths(-1);
            CreateCalendar();
        }

        private void CreateCalendar()
        {
            _days.Clear();
            DateTime firstDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            int startIndex = typeof(DayOfWeek).GetEnumNames().ToList().IndexOf(firstDate.DayOfWeek.ToString());
            DateTime startDay = firstDate.AddDays(-startIndex);
            int totalDays = DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
            for (DateTime date = startDay; date <= DateTime.Parse(_currentDate.ToString("yyyy-MM-") + totalDays.ToString("00")); date = date.AddDays(1))
            {
                string additionalClass = "disabled";
                if (date >= firstDate)
                {
                    additionalClass = "";
                }
                _days.Add((additionalClass, date.Day));
            }
            StateHasChanged();
        }
    }
}
