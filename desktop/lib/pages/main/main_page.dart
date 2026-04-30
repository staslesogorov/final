import 'dart:math';
import 'package:desktop/api.dart';
import 'package:desktop/pages/main/effectivnost_seti.dart';
import 'package:desktop/pages/main/sosstoyanie_seti.dart';
import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:graphic/graphic.dart';

final Map<String, Widget> items = {
  "Эффективность сети": EffectivnpostSeti(),
  "Состояние сети": SosstoyanieSeti(),
  "Сводка": Text("Сводка"),
  "Динамика продаж за последние 10 дней": Text(
    "Динамика продаж за последние 10 дней",
  ),
  "Новости": Text("Новости"),
};

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
                children: List.generate(items.length, (index) {
                  return Card(
                    title: items.keys.toList()[index],
                    child: items.values.toList()[index],
                  );
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
  const Card({super.key, required this.title, required this.child});
  final String title;
  final Widget child;

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
          Expanded(child: Center(child: child)),
        ],
      ),
    );
  }
}
