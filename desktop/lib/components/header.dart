import 'package:flutter/material.dart';

class Header extends StatelessWidget {
  const Header({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(border: Border.all(color: Colors.grey)),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [HeaderTitle(), DropDown()],
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
  const DropDown({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        border: Border(left: BorderSide(color: Colors.grey)),
      ),
      padding: EdgeInsets.all(20),
      child: Row(
        spacing: 5,
        children: [
          Icon(Icons.flag),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text("ПОЛЬЗОВАТЕЛЬ", style: TextStyle(fontSize: 14)),
              Text(
                "Администратор",
                style: TextStyle(fontSize: 12, color: Colors.grey[600]),
              ),
            ],
          ),
          Icon(Icons.arrow_drop_down),
        ],
      ),
    );
  }
}
