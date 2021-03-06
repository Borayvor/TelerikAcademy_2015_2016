﻿namespace Dealership.Common
{
    public class Constants
    {
        // String lengths
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        public const int MinPasswordLength = 5;
        public const int MaxPasswordLength = 30;
        public const int MinCategoryLength = 3;
        public const int MaxCategoryLength = 10;
        public const int MinMakeLength = 2;
        public const int MaxMakeLength = 15;
        public const int MinModelLength = 1;
        public const int MaxModelLength = 15;
        public const int MinCommentLength = 3;
        public const int MaxCommentLength = 200;

        // Numbers validation
        public const int MinWheels = 2;
        public const int MaxWheels = 10;
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;

        // Strings for validation
        public const string StringMustBeBetweenMinAndMax = "{0} must be between {1} and {2} characters long!";
        public const string NumberMustBeBetweenMinAndMax = "{0} must be between {1} and {2}!";

        // Vehicle max to add if not VIP
        public const int MaxVehiclesToAdd = 5;

        // Username pattern
        public const string UsernamePattern = "^[A-Za-z0-9]+$";
        public const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";

        // Strings for vehicles, comments and users
        public const string InvalidSymbols = "{0} contains invalid symbols!";

        public const string UserToString = "Username: {0}, FullName: {1} {2}, Role: {3}";

        public const string CommentCannotBeNull = "Comment cannot be null!";
        public const string VehicleCannotBeNull = "Vehicle cannot be null!";

        public const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        public const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";

        public const string YouAreNotTheAuthor = "You are not the author!";
        public const string UserCannotBeNull = "User cannot be null!";

        // Added additionally
        public const string PropertyCannotBeNull = "{0} cannot be null!";

        // Commands constants
        public const string InvalidCommand = "Invalid command!";

        public const string UserAlreadyExist = "User {0} already exist. Choose a different username!";
        public const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        public const string UserRegisterеd = "User {0} registered successfully!";
        public const string UserNotLogged = "You are not logged! Please login first!";
        public const string NoSuchUser = "There is no user with username {0}!";
        public const string UserLoggedOut = "You logged out!";
        public const string UserLoggedIn = "User {0} successfully logged in!";
        public const string WrongUsernameOrPassword = "Wrong username or password!";
        public const string YouAreNotAnAdmin = "You are not an admin!";

        public const string CommentAddedSuccessfully = "{0} added comment successfully!";
        public const string CommentRemovedSuccessfully = "{0} removed comment successfully!";

        public const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";
        public const string VehicleAddedSuccessfully = "{0} added vehicle successfully!";

        public const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";
        public const string RemovedCommentDoesNotExist = "Cannot remove comment! The comment does not exist!";

        public const string CommentDoesNotExist = "The comment does not exist!";
        public const string VehicleDoesNotExist = "The vehicle does not exist!";

        // Command names
        public const string RegisterUserCommandName = "RegisterUser";
        public const string LoginCommandName = "Login";
        public const string LogoutCommandName = "Logout";
        public const string AddVehicleCommandName = "AddVehicle";
        public const string RemoveVehicleCommandName = "RemoveVehicle";
        public const string AddCommentCommandName = "AddComment";
        public const string RemoveCommentCommandName = "RemoveComment";
        public const string ShowUsersCommandName = "ShowUsers";
        public const string ShowVehiclesCommandName = "ShowVehicles";

    }
}
