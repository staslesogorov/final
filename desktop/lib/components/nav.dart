import 'package:flutter/material.dart';

class Nav extends StatelessWidget {
  final String page;
  const Nav({super.key, required this.page});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(20),
      color: Colors.black87,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            spacing: 140,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text("Навигация", style: TextStyle(color: Colors.white)),
              Icon(Icons.menu, color: Colors.white),
            ],
          ),
          Row(
            children: [
              Text(
                "ООО Торговые автоматы",
                style: TextStyle(color: Colors.white, fontSize: 20),
              ),
            ],
          ),
          Row(
            children: [Text(page, style: TextStyle(color: Colors.grey[600]))],
          ),
        ],
      ),
    );
  }
}
