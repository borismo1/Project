namespace BackEnd.Service
{
    public class IItemService
    {
        Task<ServiceResponce<GetCustomerDto>> GetItemById(int id);

    }
}
