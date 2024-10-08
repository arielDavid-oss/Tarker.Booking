namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocumentNumber
{
    public interface IGetCustomerByDocumentNumberQuery
    {
        Task<GetCustomerByDocumentNumberModel> Execute( string DocumentNumber);

    }
}

