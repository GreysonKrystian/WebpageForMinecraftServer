﻿using Microsoft.AspNetCore.Identity;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility.Exceptions;

namespace MinecraftServerWeb.Utility.Blockade
{
    public class LockUserHandler
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public LockUserHandler(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork)
        {
                _userManager = userManager;
                _unitOfWork = unitOfWork;
        }

        public bool TimeLock(string userId, DateTime? endDate)
        {
            var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            if (user == null)
                throw new UserNotFoundException("User with this ID not found in database");
            var lockUserResult = _userManager.SetLockoutEnabledAsync(user, true).GetAwaiter().GetResult();
            if (endDate != null)
            {
                var setLockTimeResult = _userManager.SetLockoutEndDateAsync(user, endDate).GetAwaiter().GetResult();
                return lockUserResult.Succeeded && setLockTimeResult.Succeeded;
            }
            return lockUserResult.Succeeded;

        }

        public bool Unlock(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            if (user == null)
                throw new UserNotFoundException("User with this ID not found in database");
            var unlockUserResult = _userManager.SetLockoutEnabledAsync(user, false).GetAwaiter().GetResult();
            var removeTimeLockResult = _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MinValue).GetAwaiter().GetResult();
            return unlockUserResult.Succeeded && removeTimeLockResult.Succeeded;
        }

        public void PermanentDeleteUser(string userId)
        {
            User user = (User)_userManager.FindByIdAsync(userId).GetAwaiter().GetResult();
            if (user == null)
                throw new UserNotFoundException("User with this ID not found in database");
            _unitOfWork.User.Remove(user);
            _unitOfWork.Commit();
        }
    }
}
