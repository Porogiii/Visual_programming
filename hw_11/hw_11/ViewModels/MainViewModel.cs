using CommunityToolkit.Mvvm.ComponentModel;
using hw_11.Struct;

namespace hw_11.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private User _userData = new User
    {
        id = 1,
        name = "Name",
        username = "Username",
        email = "www@www.com",
        address = new Address()
        {
            street ="street",
            suite="sioteee",
            city = "ZZZ",
            zipcode="ziziizzppz",
        },
        phone = "+333333",
        website = "wdddf",
        company = new Company()
        {
            name = "Company",
            catchPhrase = "dsdsdsds",
            bs = "ASSSaa",
        }
    };
}
