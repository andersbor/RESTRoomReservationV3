using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomReservationV3.Controllers;
using RoomReservationV3.model;
//using System.Linq;

namespace ControllerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAvailableRooms()
        {
            RoomsController controller = new RoomsController();
            var rooms = controller.GetAvailableRooms(10);
           // Assert.AreEqual(3, rooms.Count());

            rooms = controller.GetAvailableRooms(1569574801);
           // Assert.AreEqual(2, rooms.Count());
        }

        [TestMethod]
        public void TestReservationIntersect()
        {
            Reservation reservation1 = new Reservation { FromTime = 10, ToTime = 20 };
            Reservation reservation2 = new Reservation { FromTime = 20, ToTime = 30 };
            Reservation reservation3 = new Reservation { FromTime = 12, ToTime = 15 };
            Reservation reservation4 = new Reservation {FromTime = 8, ToTime = 14};
            Reservation reservation5 = new Reservation {FromTime = 8, ToTime = 22};

            Assert.IsTrue(reservation1.Intersects(reservation1));
            Assert.IsFalse(reservation1.Intersects(reservation2));
            Assert.IsTrue(reservation1.Intersects(reservation3));
            Assert.IsFalse(reservation2.Intersects(reservation3));
            Assert.IsTrue((reservation1.Intersects(reservation4)));
            Assert.IsTrue(reservation5.Intersects(reservation1));
            Assert.IsTrue(reservation1.Intersects(reservation5));
            //Assert.Fail();
        }

        

        [TestMethod]
        public void TestIntersect()
        {
            Assert.IsTrue(Interval.Intersects(1,10,1,10));
            Assert.IsTrue(Interval.Intersects(1, 10, 9, 11));
            Assert.IsTrue(Interval.Intersects(0, 2, 1, 10));
            Assert.IsTrue(Interval.Intersects(1, 10, 2, 9));
            Assert.IsTrue(Interval.Intersects(1, 10, 0, 11));
            Assert.IsTrue(Interval.Intersects(0, 11, 1, 10));
            Assert.IsFalse(Interval.Intersects(1, 10, 10, 11));
        }
    }
}
