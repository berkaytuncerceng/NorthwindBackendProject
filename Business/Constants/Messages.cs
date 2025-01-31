﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "The product has added successfully";
        public static string ProductUpdated = "The product has updated successfully";
        public static string ProductDeleted = "The product has deleted successfully";
        public static string CategoryAdded = "The category has added successfully";
        public static string CategoryUpdated = "The category has updated successfully";
        public static string CategoryDeleted = "The category has deleted successfully";
        public static string UserNotFound = "The user couldnt be found";

        public static string PasswordError = "Password is NOT right.";
        public static string UserFound = "This user already exists.";
        public static string UserRegistered = "Registration is successful";
        public static string AccessTokenCreated = "Access Token Created";

    }
}
