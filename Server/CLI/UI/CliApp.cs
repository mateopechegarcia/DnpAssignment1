using CLI.UI.ManagePosts;
using CLI.UI.ManageUsers;
using RepositoryContracts;

namespace CLI.UI;

public class CliApp {
    private readonly IUserRepository userRepository;
    private readonly ICommentRepository commentRepository;
    private readonly IPostRepository postRepository;

    public CliApp(
        IUserRepository userRepository,
        ICommentRepository commentRepository,
        IPostRepository postRepository) {
        this.userRepository = userRepository;
        this.commentRepository = commentRepository;
        this.postRepository = postRepository;
    }

    public async Task StartAsync() {
        while (true) {
            Console.WriteLine();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Manage users");
            Console.WriteLine("2. Manage posts");
            Console.WriteLine("0. Exit");

            string? choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    ManageUsersView manageUsersView =
                        new ManageUsersView(userRepository);

                    await manageUsersView.ShowAsync();
                    break;

                case "2":
                    ManagePostsView managePostsView =
                        new ManagePostsView(
                            userRepository,
                            postRepository,
                            commentRepository
                        );

                    await managePostsView.ShowAsync();
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