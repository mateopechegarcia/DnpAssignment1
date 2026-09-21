using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView {
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly ICommentRepository commentRepository;

    public ManagePostsView(
        IUserRepository userRepository,
        IPostRepository postRepository,
        ICommentRepository commentRepository) {
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.commentRepository = commentRepository;
    }

    public async Task ShowAsync() {
        while (true) {
            Console.WriteLine();
            Console.WriteLine("MANAGE POSTS");
            Console.WriteLine("1. Create post");
            Console.WriteLine("2. Add comment");
            Console.WriteLine("3. View posts");
            Console.WriteLine("4. View specific post");
            Console.WriteLine("0. Back");

            string? choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    CreatePostView createPostView =
                        new CreatePostView(userRepository, postRepository);

                    await createPostView.ShowAsync();
                    break;

                case "2":
                    AddCommentView addCommentView =
                        new AddCommentView(
                            userRepository,
                            postRepository,
                            commentRepository
                        );

                    await addCommentView.ShowAsync();
                    break;

                case "3":
                    ListPostsView listPostsView =
                        new ListPostsView(postRepository);

                    listPostsView.Show();
                    break;

                case "4":
                    SinglePostView singlePostView =
                        new SinglePostView(postRepository, commentRepository);

                    await singlePostView.ShowAsync();
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