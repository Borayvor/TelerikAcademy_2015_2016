namespace Dealership.Engine.Factories
{
    using Contracts.Commands;
    using Contracts.Factories;
    using Engine.Commands;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommands()
        {
            var registerUser = new RegisterUser();
            var login = new Login();
            var logout = new Logout();
            var addVehicle = new AddVehicle();
            var removeVehicle = new RemoveVehicle();
            var addComment = new AddComment();
            var removeComment = new RemoveComment();
            var showUsers = new ShowUsers();
            var showVehicles = new ShowVehicles();

            registerUser.SetSuccessor(login);
            login.SetSuccessor(logout);
            logout.SetSuccessor(addVehicle);
            addVehicle.SetSuccessor(removeVehicle);
            removeVehicle.SetSuccessor(addComment);
            addComment.SetSuccessor(removeComment);
            removeComment.SetSuccessor(showUsers);
            showUsers.SetSuccessor(showVehicles);

            return registerUser;
        }
    }
}
