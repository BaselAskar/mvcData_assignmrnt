namespace mvcData_assignmrnt.Data
{
    public class IdCounters
    {
        private static int currentPersonId = 0;

        public static int NextPersonId => ++currentPersonId;
    }
}
