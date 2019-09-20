using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomReservationV3.model;

namespace ControllerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReservationIntersect()
        {
            Reservation reservation1 = new Reservation { FromTime = 10, ToTime = 20 };
            Reservation reservation2 = new Reservation { FromTime = 20, ToTime = 30 };
            Reservation reservation3 = new Reservation { FromTime = 12, ToTime = 15 };

            Assert.IsFalse(reservation1.Intersects(reservation2));
            Assert.IsTrue(reservation1.Intersects(reservation3));
            Assert.IsFalse(reservation2.Intersects(reservation3));
        }
    }
}
