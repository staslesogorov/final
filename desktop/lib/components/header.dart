import 'package:desktop/api.dart';
import 'package:desktop/user.dart';
import 'package:flutter/material.dart';

class Header extends StatelessWidget {
  const Header({super.key, this.user});

  final User? user;

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(border: Border.all(color: Colors.grey)),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          HeaderTitle(),
          DropDown(user: user),
        ],
      ),
    );
  }
}

class HeaderTitle extends StatelessWidget {
  const HeaderTitle({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(20),
      child: Row(
        spacing: 20,

        children: [
          Icon(Icons.car_rental),
          Text("Логотип", style: TextStyle(fontSize: 24)),
        ],
      ),
    );
  }
}

class DropDown extends StatelessWidget {
  const DropDown({super.key, required this.user});

  final User? user;

  @override
  Widget build(BuildContext context) {
    print(user);
    return Container(
      decoration: BoxDecoration(
        border: Border(left: BorderSide(color: Colors.grey)),
      ),
      padding: EdgeInsets.all(10),
      child: PopupMenuButton<String>(
        offset: Offset(0, 50),
        onSelected: (value) {
          if (value == 'logout') {
            removeToken();
            removeUser();
            Navigator.pushReplacementNamed(context, '/');
          }
        },
        itemBuilder: (context) => [
          PopupMenuItem(
            value: 'account',
            child: Row(
              spacing: 10,
              children: [Icon(Icons.person), Text('Мой профиль')],
            ),
          ),
          PopupMenuItem(
            value: 'sessions',
            child: Row(
              spacing: 10,
              children: [Icon(Icons.lock), Text('Мои сессии')],
            ),
          ),
          PopupMenuItem(
            value: 'logout',
            child: Row(
              spacing: 10,
              children: [Icon(Icons.logout), Text('Выход')],
            ),
          ),
        ],
        child: Row(
          spacing: 10,
          children: [
            Icon(Icons.flag),
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(user!.fio, style: TextStyle(fontSize: 14)),
                Text(
                  user!.role,
                  style: TextStyle(fontSize: 12, color: Colors.grey),
                ),
              ],
            ),
            Icon(Icons.arrow_drop_down),
          ],
        ),
      ),
    );
  }
}
