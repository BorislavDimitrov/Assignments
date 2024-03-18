using FilesystemAndStreams;
using FilesystemAndStreams.Services;

var logger = new Logger();
var userService = new UserService(logger);

userService.Register("TestTest", "testpassword123");
userService.Register("TestTest2", "testpassword123");
userService.SignIn("TestTest", "testpassword123");
userService.SignIn("TestTest2", "testpassword");

