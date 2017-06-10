function UserDetailsvalid() {
    var Username, Password, RePassword, Email, Firstname, Lastname;
    debugger;
    Username = document.getElementById("Username").value;
    Password = document.getElementById("Password").value;
    RePassword = document.getElementById("txtPasswordConfirm").value;
    Email = document.getElementById("Email").value;
    Firstname = document.getElementById("FirstName").value;
    Lastname = document.getElementById("LastName").value;

    if (Username == "" || Password == "" || RePassword == "" || Email == "" || Firstname == "" || Lastname == "") {
        $('.tooltipped').tooltip({ delay: 50 });
        Materialize.toast('Please enter all values', 4000)
        return false;
    }

    if (Password != RePassword) {
        $('.tooltipped').tooltip({ delay: 50 });
        Materialize.toast('Password Does not match', 4000)
        return false;
    }

    var atpos = Email.indexOf("@");
    var dotpos = Email.lastIndexOf(".");
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= Email.length) {
        alert("Not a valid e-mail address");
        return false;
    }
}