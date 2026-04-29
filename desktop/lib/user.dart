class User {
  final String fullName;
  final String role;
  final String photo;

  User({required this.fullName, required this.role, required this.photo});
}

User? user;

void setUser(User u) {
  user = u;
}

User? getUser() => user;

void removeUser() {
  user = null;
}
