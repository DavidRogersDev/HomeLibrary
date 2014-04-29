using System;

namespace KesselRun.HomeLibrary.UiLogic.EventArgs
{
    public class AddLendingEventArgs : System.EventArgs
    {
        public readonly int BookId;
        public readonly int BorrowerId;
        public readonly DateTime DateLent;
        public readonly DateTime? DateDue;

        public AddLendingEventArgs(int bookId, int borrowerId, DateTime dateLent, DateTime? dueDate)
        {
            BookId = bookId;
            BorrowerId = borrowerId;
            DateLent = dateLent;
            DateDue = dueDate;
        }
    }
}
