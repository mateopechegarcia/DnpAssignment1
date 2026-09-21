using RepositoryContracts;

namespace CLI.UI.ManageUsers;

public class ManageUsersView {
    private readonly IUserRepository userRepository;

    public ManageUsersView(IUserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public async Task ShowAsync() {
        while (true) {
            Console.WriteLine();
            Console.WriteLine("MANAGE USERS");
            Console.WriteLine("1. Create user");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateUserView createUserView =
                        new CreateUserView(userRepository);

                    await createUserView.ShowAsync();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}