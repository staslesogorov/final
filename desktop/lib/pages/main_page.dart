import 'package:flutter/material.dart';

final List<String> items = [
  "Эффективность сети",
  "Состояние сети",
  "Сводка",
  "Динамика продаж за последние 10 дней",
  "Новости",
];

class MainPage extends StatelessWidget {
  const MainPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.grey[200],
      child: Column(
        children: [
          Container(
            alignment: Alignment.centerLeft,
            padding: EdgeInsets.only(left: 20, right: 20, top: 20, bottom: 10),
            child: Text(
              "Личный кабинет. Главная",
              style: TextStyle(fontSize: 24, color: Colors.black),
            ),
          ),
          Expanded(
            child: Container(
              child: GridView.count(
                crossAxisCount: 3,
                children: List.generate(5, (index) {
                  return Card(title: items[index]);
                }),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class Card extends StatelessWidget {
  const Card({super.key, required this.title});
  final String title;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.all(20),
      color: Colors.white,
      child: Column(
        children: [
          Container(
            padding: EdgeInsets.all(10),
            child: Text(title, style: TextStyle(fontSize: 18)),
          ),
          Expanded(child: Center(child: Text(title))),
        ],
      ),
    );
  }
}
