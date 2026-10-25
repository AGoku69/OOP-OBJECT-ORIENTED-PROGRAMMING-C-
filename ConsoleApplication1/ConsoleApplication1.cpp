#include <iostream>
#include <string>
using namespace std;

class User {
private:
    string name;
    string password;
    string role;

public:
    // Default Constructor
    User() {
        cout << "Default Constructor Called" << endl;
    }

    // Parameterized Constructor
    User(string name, string password, string role) {
        this->name = name;
        this->password = password;
        this->role = role;
    }

    // Sign In Function
    bool signIn(string n, string p) {
        return (name == n && password == p);
    }

    // Show Data Function
    void showData() {
        cout << "Name: " << name << endl;
        cout << "Role: " << role << endl;
    }

    // Copy Constructor
    User(const User& u) {
        name = u.name;
        password = u.password;
        role = u.role;
    }

    // Destructor
    ~User() {
        cout << "Destructor Called for user: "
            << name << endl;
    }
};

int main() {
    string name, password, role;
    string n, p;

    cout << "Class Created Successfully" << endl;
    cout << "==========================================================" << endl;
    cout << "=====          Smart Farm Management System          =====" << endl;
    cout << "==========================================================" << endl;

    cout << "\n ===== Sign Up =====" << endl;

    cout << "Enter Your Name: ";
    getline(cin, name);

    cout << "Enter Your Password: ";
    getline(cin, password);

    cout << "Enter Your Role: ";
    getline(cin, role);

    User* user = new User(name, password, role);
    cout << " User Created Successfully!" << endl;

    cout << "\n===== Sign In =====" << endl;

    cout << "Enter Your Name: ";
    getline(cin, n);

    cout << "Enter Your Password: ";
    getline(cin, p);

    if (user->signIn(n, p)) {
        cout << "Login Successful!" << endl;
        user->showData();
    }
    else {
        cout << "Invalid Credentials!" << endl;
    }

    cout << "\n===== Copy Constructor =====" << endl;

    User copyUser(*user);

    cout << "\nOriginal User:" << endl;
    user->showData();

    cout << "\nCopied User:" << endl;
    copyUser.showData();

    delete user;

    return 0;
}