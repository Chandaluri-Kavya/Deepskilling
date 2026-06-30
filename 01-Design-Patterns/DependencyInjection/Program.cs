ICustomerRepository repository = new CustomerRepository();

CustomerService service = new CustomerService(repository);

service.ShowCustomer();