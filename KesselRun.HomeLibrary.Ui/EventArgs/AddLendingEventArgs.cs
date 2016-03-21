using System;

namespace KesselRun.HomeLibrary.Ui.EventArgs
{
    public class AddLendingEventArgs
    {
        public readonly int bookId;
        public readonly int borrowerId;
        public readonly DateTime dateLent;
        public readonly DateTime? dateDue;

        public AddLendingEventArgs(int bookId, int borrowerId, DateTime dateLent, DateTime? dueDate)
        {
            this.bookId = bookId;
            this.borrowerId = borrowerId;
            this.dateLent = dateLent;
            this.dateDue = dueDate;
        }
    }
}
