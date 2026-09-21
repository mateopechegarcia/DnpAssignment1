using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class SinglePostView {
    private readonly IPostRepository postRepository;
    private readonly ICommentRepository commentRepository;

    public SinglePostView(
        IPostRepository postRepository,
        ICommentRepository commentRepository) {
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
    }

    public async Task ShowAsync() {
        Console.Write("Post ID: ");

        if (!int.TryParse(Console.ReadLine(), out int postId)) {
            Console.WriteLine("Invalid post ID.");
            return;
        }

        try {
            var post = await postRepository.GetSingleAsync(postId);

            Console.WriteLine();
            Console.WriteLine("Title: " + post.Title);
            Console.WriteLine("Body: " + post.Body);

            Console.WriteLine();
            Console.WriteLine("Comments:");

            var comments = commentRepository
                .GetMany()
                .Where(comment => comment.PostId == post.Id);

            foreach (var comment in comments) {
                Console.WriteLine(
                    $"User {comment.UserId}: {comment.Body}"
                );
            }
        }
        catch (InvalidOperationException) {
            Console.WriteLine("Post does not exist.");
        }
    }
}