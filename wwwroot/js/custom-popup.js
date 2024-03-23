window.showEditPopup = (userId, currentEmail) => {
    // Show a custom popup box with two input fields for new email and password
    var newEmail = prompt("Enter new email:", currentEmail);
    var newPassword = prompt("Enter new password:");

    // Perform any validation or checks on the new email and password

    // If new email and password are provided, call a function to update the user
    if (newEmail && newPassword) {
        updateUser(userId, newEmail, newPassword);
    }
}

function updateUser(userId, newEmail, newPassword) {
    // Call your C# method to update the user with the new email and password
    DotNet.invokeMethodAsync('SecureLogin', 'UpdateUserAndRefreshTable', userId, newEmail, newPassword)
        .then(result => {
            // Handle the result if needed
            console.log('User updated successfully');
        })
        .catch(error => {
            console.error('Error updating user:', error);
        });
}
