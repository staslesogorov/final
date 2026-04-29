class User {
  final String full_name;
  final String role;

  User({required this.full_name, required this.role});
}

User? user;

void setUser(User u) {
  user = u;
}

User? getUser() => user;

void removeUser() {
  user = null;
}
