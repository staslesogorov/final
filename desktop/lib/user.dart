class User {
  final String fio;
  final String role;

  User({required this.fio, required this.role});
}

User? user;

void setUser(User u) {
  user = u;
}

User? getUser() => user;

void removeUser() {
  user = null;
}
