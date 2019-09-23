namespace RoomReservationV3.model
{
    public class Reservation
    {
        public int Id { get; set; }

        // https://www.unixtimestamp.com/
        // https://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
        // Todo class Interval?
        public int FromTime { get; set; }

        // constraint: FromTime <= ToTime
        public int ToTime { get; set; }
        public string UserId { get; set; }
        public string Purpose { get; set; }

        // constraint: must refer to an existing RoomId
        public int RoomId { get; set; }

        // public string DeviceId { get; set; }

        public bool Intersects(Reservation other) // todo static?
                                                  // todo roomId must be taken in into consideration
        {
            //return Intersects(other.FromTime, other.ToTime);
            return this.RoomId == other.RoomId &&
                   Interval.Intersects(this.FromTime, this.ToTime, other.FromTime, other.ToTime);
            //return (FromTime < other.FromTime && other.FromTime < ToTime) ||
            //       (FromTime < other.ToTime && other.ToTime < ToTime);
        }

        public bool Intersects(int fromTime, int toTime)
        {
            //return (FromTime < fromTime && fromTime < ToTime) ||
            //       (FromTime < toTime && toTime < ToTime);
            //return this.FromTime < toTime && FromTime < this.ToTime;
            return Interval.Intersects(this.FromTime, this.ToTime, fromTime, toTime);
        }
    }

    public class Interval
    {
        // https://stackoverflow.com/questions/13513932/algorithm-to-detect-overlapping-periods
        public static bool Intersects(int a, int b, int c, int d)
        {
            return a < d && c < b;
        }
    }
}
