using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class AddCommentView {
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly ICommentRepository commentRepository;

    public AddCommentView(
        IUserRepository userRepository,
        IPostRepository postRepository,
        ICommentRepository commentRepository) {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
    }

    public async Task ShowAsync() {
        Console.Write("Comment: ");
        string body = Console.ReadLine() ?? "";

        Console.Write("User ID: ");

        if (!int.TryParse(Console.ReadLine(), out int userId)) {
            Console.WriteLine("Invalid user ID.");
            return;
        }

        Console.Write("Post ID: ");

        if (!int.TryParse(Console.ReadLine(), out int postId)) {
            Console.WriteLine("Invalid post ID.");
            return;
        }

        bool userExists =
            userRepository.GetMany().Any(user => user.Id == userId);

        if (!userExists) {
            Console.WriteLine("User does not exist.");
            return;
        }

        bool postExists =
            postRepository.GetMany().Any(post => post.Id == postId);

        if (!postExists) {
            Console.WriteLine("Post does not exist.");
            return;
        }

        Comment comment = new Comment {
            Body = body,
            UserId = userId,
            PostId = postId
        };

        await commentRepository.AddAsync(comment);

        Console.WriteLine("Comment added.");
    }
}