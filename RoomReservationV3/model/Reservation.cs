﻿namespace RoomReservationV3.model
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
                                                  // todo test Intersects
        // todo roomId must be taken in into consideration
        {
            return Intersects(other.FromTime, other.ToTime);
            //return (FromTime < other.FromTime && other.FromTime < ToTime) ||
            //       (FromTime < other.ToTime && other.ToTime < ToTime);
        }

        public bool Intersects(long fromTime, long toTime)
        {
            return (FromTime < fromTime && fromTime < ToTime) ||
                   (FromTime < toTime && toTime < ToTime);
        }
    }
}
