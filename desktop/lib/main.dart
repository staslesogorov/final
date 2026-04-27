import 'package:desktop/components/header.dart';
import 'package:desktop/components/menu.dart';
import 'package:desktop/components/nav.dart';
import 'package:desktop/pages/login_page.dart';
import 'package:desktop/pages/main_page.dart';
import 'package:desktop/pages/pages.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: LoginPage(),
      routes: {'/home': (context) => Layout()},
    );
  }
}

final Map<String, Widget> pages = {
  "Главная": MainPage(),
  "Монитор ТА": MonitorPage(),
  "Детальный отчеты": ReportsPage(),
  "Учет ТМЦ": InventoryPage(),
  "Администрирование": AdminPage(),
};

class Layout extends StatefulWidget {
  const Layout({super.key});

  @override
  State<Layout> createState() => _LayoutState();
}

class _LayoutState extends State<Layout> {
  String selectedPage = "Главная";

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Header(),
          Nav(page: selectedPage),
          Expanded(
            child: Row(
              children: [
                Menu(onSelect: (page) => setState(() => selectedPage = page)),
                Expanded(child: pages[selectedPage]!),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
