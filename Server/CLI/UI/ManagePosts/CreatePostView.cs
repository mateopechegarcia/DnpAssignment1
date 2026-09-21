using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class CreatePostView {
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;

    public CreatePostView(
        IUserRepository userRepository,
        IPostRepository postRepository) {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
    }

    public async Task ShowAsync() {
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";

        Console.Write("Body: ");
        string body = Console.ReadLine() ?? "";

        Console.Write("User ID: ");

        if (!int.TryParse(Console.ReadLine(), out int userId)) {
            Console.WriteLine("Invalid user ID.");
            return;
        }

        bool userExists =
            userRepository.GetMany().Any(user => user.Id == userId);

        if (!userExists) {
            Console.WriteLine("User does not exist.");
            return;
        }

        Post post = new Post {
            Title = title,
            Body = body,
            UserId = userId
        };

        await postRepository.AddAsync(post);

        Console.WriteLine("Post created with ID: " + post.Id);
    }
}