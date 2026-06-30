public class CustomerService
{
    private ICustomerRepository repository;

    public CustomerService(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    public void ShowCustomer()
    {
        repository.Display();
    }
}